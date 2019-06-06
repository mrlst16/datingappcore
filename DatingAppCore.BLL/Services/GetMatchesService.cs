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
    public class GetMatchesService : IGetMatchesService
    {
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

                foreach (var personWhoSwipedOnTheUsed in peopleWhoSwipedOnTheUser)
                {
                    if (peopleTheUserSwipedOn.Contains(personWhoSwipedOnTheUsed))
                        resultUsers.Add(personWhoSwipedOnTheUsed);
                }

                return resultUsers.Select(x => RepoCache.Get<User>().GetUser(new Requests.GetUserRequest()
                {
                    UserID = x,
                    IncludeMessages = true,
                    IncludePhotos = true,
                    IncludeProfile = true,
                    IncludeReviews = true
                }));
            });
        }

        public async Task<Response<bool>> IsMatch(Guid user1id, Guid user2id)
        {
            return Response<bool>.Wrap(() =>
            {
                var repo = RepoCache.Get<Swipe>();
                var swipeFromUser1 = repo.GetQuery()
                    .FirstOrDefault(
                        x => x.UserFromID == user1id
                        && x.UserToID == user2id
                        && x.IsLike
                    );
                if (swipeFromUser1 == null) return false;

                var swipeFromUser2 = repo.GetQuery()
                    .FirstOrDefault(
                        x => x.UserFromID == user2id
                        && x.UserToID == user1id
                        && x.IsLike
                    );
                if (swipeFromUser2 == null) return false;

                return true;
            });
        }
    }
}
