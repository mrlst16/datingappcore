using CommonCore.Repo;
using DatingAppCore.DTO.Matching;
using DatingAppCore.Repo.Matching;

namespace DatingAppCore.BLL.Adapters
{
    public static class MatchesAdapterExtensions
    {
        public static Swipe ToEntity(this SwipeDTO swipe)
        {
            return new Swipe()
            {
                ID = swipe.ID,
                UserFromID = swipe.UserFromID,
                UserToID = swipe.UserToID,
                IsLike = swipe.IsLike
            }.EnsureID();
        }

        public static SwipeDTO ToDto(this Swipe swipe)
        {
            return new SwipeDTO()
            {
                ID = swipe.ID,
                UserFromID = swipe.UserFromID,
                UserToID = swipe.UserToID,
                IsLike = swipe.IsLike
            };
        }

    }
}
