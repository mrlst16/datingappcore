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
                    ID = Guid.NewGuid(),
                    ReviewID = result.ID,
                    CreateDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow,
                    ReviewBadgeTemplateID = x.ID
                })
                .ToList();

            return result;
        }

        public static ReviewBadgeTemplateDTO ToDto(this ReviewBadgeTemplate entity)
        {
            return new ReviewBadgeTemplateDTO()
            {
                ID = entity.ID,
                ClientID = entity.ClientID,
                Name = entity.Name
            };
        }

        public static ReviewBadgeTemplate ToEntity(this ReviewBadgeTemplateDTO dto)
        {
            return new ReviewBadgeTemplate()
            {
                ID = dto.ID,
                ClientID = dto.ClientID,
                Name = dto.Name
            }.EnsureID();
        }
    }
}
