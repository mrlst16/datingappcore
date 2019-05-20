using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Repo.Requests;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Services
{
    public class PotentialMatchesService : IPotentialMatchesService
    {
        async Task<Response<IEnumerable<UserDTO>>> IPotentialMatchesService.FindPotentialMatches(FindMatchRequest request)
        {
            return Response<IEnumerable<UserDTO>>.Wrap(y =>
            {
                var users = RepoCache.RunSproc<UserDTO>(
                    new RunSprocRequest()
                    {
                        ContextType = typeof(Repo.AppContext),
                        SprocName = "PotentialMatches",
                        Parameters = new Dictionary<string, string>()
                        {
                            {"userid", request.UserID.ToString() },
                            {"skip", request.Skip.ToString() },
                            {"take", request.Take.ToString() }
                        }
                    }
                );

                try
                {
                    var ids = users.Select(x => x.ID).ToList();
                    return RepoCache.GetQuery<User>()
                        .Where(x => ids.Contains(x.ID))
                        .Include(x => x.Profile)
                        .ToList()
                        .Select(x => x.ToDto());
                }
                catch (Exception e)
                {
                    throw e;
                }
            });
        }
    }
}
