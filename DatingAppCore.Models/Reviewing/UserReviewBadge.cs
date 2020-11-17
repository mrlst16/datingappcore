using System;
using CommonCore.Repo.Entities;

namespace DatingAppCore.Entities.Reviewing
{
    public class UserReviewBadge : EntityBase
    {
        public Guid ReviewBadgeTemplateID { get; set; }
        public Guid ReviewID { get; set; }
    }
}