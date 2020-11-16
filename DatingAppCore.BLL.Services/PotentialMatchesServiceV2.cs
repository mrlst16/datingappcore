using System;
using System.Collections.Generic;
using System.IO;
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
using DatingAppCore.Repo;
using DatingAppCore.Repo.EF.Members;
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
                var userRepo = RepoCache.Get<User>();
                var user = GetUser(userRepo, new GetUserRequest()
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
                        ContextType = typeof(Repo.EF.AppContext),
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

        private UserDTO GetUser(Repository<User> repository, GetUserRequest request)
        {
            var query = repository
                    .GetQuery()
                    .Where(x => x.ID == request.UserID);

            if (request.IncludeProfile)
            {
                query = query.Include(x => x.Profile);
            }

            if (request.IncludeMessages)
            {
                query = query.Include(x => x.Inbox);
                query = query.Include(x => x.Sent);
            }

            if (request.IncludeSwipes)
            {
                query = query.Include(x => x.SwipesReceived);
                query = query.Include(x => x.SwipesSent);
            }

            if (request.IncludePhotos)
            {
                query = query.Include(x => x.Photos);
            }

            if (request.IncludeReviews)
            {
                query = query.Include(x => x.ReviewReceived);
                query = query.Include(x => x.ReviewsSent);
            }

            if (request.IncludePermissions)
            {
                query = query.Include(x => x.AsGrantee);
                query = query.Include(x => x.AsGrantor);
            }

            var result = query
                .FirstOrDefault()
                ?.ToDto();

            result.Photos = result
                .Photos
                ?.OrderBy(x => x.Rank)
                .ToList()
                ?? null;

            if (!result?.Photos?.Any() ?? false)
            {
                result.Photos = new List<PhotoDTO>()
                {
                    new PhotoDTO()
                    {
                        Access = Dto.AccessLevelEnum.Public,
                        Rank = 0,
                        Url = Path.Combine(SavePhotoToFileService.USER_PHOTOS_FOLDER, Guid.Empty.ToString(), $"{Guid.Empty}.jpg"),
                        FileName = $"{Guid.Empty}.jpg",
                        UserID = Guid.Empty
                    }
                };
            }

            return result;
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