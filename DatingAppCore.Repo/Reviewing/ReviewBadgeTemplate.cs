using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Repo.Reviewing
{
    public class ReviewBadgeTemplate : EntityBase
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }

        public ICollection<UserReviewBadge> UserReviewBadges { get; set; }
    }
}
