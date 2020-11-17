using CommonCore.Repo.Entities;
using System;

namespace DatingAppCore.Entities.Reviewing
{
    public class ReviewBadgeTemplate : EntityBase
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }
    }
}
