using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Reviewing;
//using DatingAppCore.Repo.EF.Reviewing;

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
                .Select(x => x.ToEntity())
                .ToList();

            return result;
        }

        public static Review ToEntity(this SaveReviewRequest dto)
        {
            var result = new Review()
            {
                ID = Guid.NewGuid(),
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

        public static UserReviewBadge ToEntity(this UserReviewBadgeDTO dto)
        {
            return new UserReviewBadge()
            {
                ID = dto.ID,
                CreateDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                ReviewID = dto.ReviewID,
                ReviewBadgeTemplateID = dto.Template.ID
            }.EnsureID();
        }
    }
}
