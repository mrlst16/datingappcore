using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Repo.Requests;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;
//using DatingAppCore.Repo;
//using DatingAppCore.Repo.EF.Members;
//using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Services
{
    public class PotentialMatchesService : IPotentialMatchesService
    {
        public async Task<Response<IEnumerable<UserDTO>>> FindPotentialMatches(FindMatchRequest request)
        {
            return Response<IEnumerable<UserDTO>>.Wrap(y =>
            {
                var users = RepoCache.RunSproc<UserSearchDTO>(
                    new RunSprocRequest()
                    {
                        ContextType = typeof(Repo.EF.AppContext),
                        SprocName = "PotentialMatches2",
                        Parameters = new Dictionary<string, string>()
                        {
                            {"userid", request.UserID.ToString() },
                            {"skip", request.Skip.ToString() },
                            {"take", request.Take.ToString() }
                        }
                    }
                );

                var ids = users.Select(x => x.userid).ToList();
                return RepoCache.GetQuery<User>()
                    .Where(x => ids.Contains(x.ID))
                    .Include(x => x.Profile)
                    .ToList()
                    .Select(x => x.ToDto());
            });
        }
    }
}