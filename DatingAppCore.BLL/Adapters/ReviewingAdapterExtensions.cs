using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo;
using DatingAppCore.Dto.Reviewing;
using DatingAppCore.Repo.Reviewing;

namespace DatingAppCore.BLL.Adapters
{
    public static class ReviewingAdapterExtensions
    {
        public static Review ToEntity(this ReviewDTO dto)
        {
            var result = new Review()
            {
                ID = dto.ID,
                Rating = dto.Rating,
                SenderID = dto.SenderID,
                ReceiverID = dto.ReceiverID
            }.EnsureID();

            result.Badges = dto
                .Badges
                .Select(x => new UserReviewBadge()
                {
                    ID = x.ID,
                    Name = x.Name,
                    ReviewID = result.ID
                })
                .ToList();

            return result;
        }
    }
}
