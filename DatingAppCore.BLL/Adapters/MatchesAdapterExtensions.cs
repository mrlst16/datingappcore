using CommonCore.Repo;
using DatingAppCore.Dto.Matching;
using DatingAppCore.Dto.Members;
//using DatingAppCore.Repo.EF.Matching;
using System;

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

        public static Match ToEntity(this MatchDTO dto)
        {
            return new Match()
            {
                ID = dto.ID,
                CreateDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LeftID = dto.LeftID,
                RightID = dto.RightID
            }
            .EnsureID();
        }

        public static MatchDTO ToDto(this Match entity)
        {
            return new MatchDTO()
            {
                ID = entity.ID,
                LeftID = entity.LeftID,
                RightID = entity.RightID
            };
        }

    }
}
