using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Matching;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IGetUserService _getUserService;
        public MatchesService(IGetUserService getUserService)
        {
            _getUserService = getUserService;
        }

        public async Task<Response<IEnumerable<UserDTO>>> GetMatches(Guid userid)
        {
            return Response<IEnumerable<UserDTO>>.Wrap(() =>
            {
                var result = new List<UserDTO>();
                var resultUsers = new List<Guid>();

                var repo = RepoCache.Get<Swipe>();
                var swipesFrom = repo.GetQuery().Where(x => x.UserFromID == userid && x.IsLike);
                var swipesTo = repo.GetQuery().Where(x => x.UserToID == userid && x.IsLike);

                var swipesToUserIds = swipesTo.Select(x => x.UserToID);
                foreach (var swipeFrom in swipesFrom)
                {
                    if (swipesToUserIds.Contains(swipeFrom.UserFromID))
                        resultUsers.Add(swipeFrom.UserFromID);
                }

                var users = resultUsers.Select(x => RepoCache.Get<User>().GetUser(new Requests.GetUserRequest()
                {
                    UserID = userid,
                    IncludeMessages = true,
                    IncludePhotos = true,
                    IncludeProfile = true,
                    IncludeReviews = true
                }));

                return result;
            });
        }
    }
}
