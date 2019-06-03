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
                var resultUsers = new List<Guid>();

                var repo = RepoCache.Get<Swipe>();
                var peopleTheUserSwipedOn = repo.GetQuery()
                    .Where(x => x.UserFromID == userid && x.IsLike)
                    .Select(x => x.UserToID)
                    .Distinct();

                var peopleWhoSwipedOnTheUser = repo.GetQuery()
                    .Where(x => x.UserToID == userid && x.IsLike)
                    .Select(x => x.UserFromID)
                    .Distinct();

                foreach (var personTheUserSwipedOn in peopleTheUserSwipedOn)
                {
                    if (peopleWhoSwipedOnTheUser.Contains(personTheUserSwipedOn))
                        resultUsers.Add(personTheUserSwipedOn);
                }

                return resultUsers.Select(x => RepoCache.Get<User>().GetUser(new Requests.GetUserRequest()
                {
                    UserID = userid,
                    IncludeMessages = true,
                    IncludePhotos = true,
                    IncludeProfile = true,
                    IncludeReviews = true
                }));
            });
        }
    }
}
