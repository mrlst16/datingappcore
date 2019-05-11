using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Repo.Requests;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo;
using DatingAppCore.Repo.Members;

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

                return UsersRepoHelper
                    .GetUsersIn(users.Select(x => x.ID).ToList())
                    .Select(x => x.ToDto());
            });
        }
    }
}
