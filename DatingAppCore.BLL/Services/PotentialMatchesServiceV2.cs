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
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.BLL.Services
{
    public class PotentialMatchesServiceV2 : IPotentialMatchesService
    {
        public async Task<Response<IEnumerable<UserDTO>>> FindPotentialMatches(FindMatchRequest request)
        {
            return Response<IEnumerable<UserDTO>>.Wrap(y =>
            {
                var user = RepoCache.Get<User>()
                    .GetUser(new GetUserRequest()
                    {
                        UserID = request.UserID,
                        IncludeProfile = true
                    });

                if (user == null) throw new Exception("No User found with id ");

                var queryString = QueryString(user.Settings);
                var parameters = new Dictionary<string, string>()
                        {
                            {"userid", request.UserID.ToString() },
                            {"skip", request.Skip.ToString() },
                            {"take", request.Take.ToString() },
                            {"queryString", queryString}
                        };

                var users = RepoCache.RunSproc<UserSearchDTO>(
                    new RunSprocRequest()
                    {
                        ContextType = typeof(Repo.AppContext),
                        SprocName = "SearchUsers",
                        Parameters = parameters
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

        private string QueryString(Dictionary<string, string> settings)
        {
            string result = string.Empty;

            if (settings?.Any() ?? false)
            {
                var s = settings
                    .Where(x => x.Value.ToLowerInvariant() != "off");
                if (s?.Any() ?? false)
                    result =
                    s.Select(x => $"{x.Key}={x.Value}")
                    .Aggregate((x, y) => $"{x},{y}")
                    .Trim(' ', ',');
            }

            return result;
        }
    }
}