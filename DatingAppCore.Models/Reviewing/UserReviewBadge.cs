using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.Repo.Reviewing
{
    public class UserReviewBadge : EntityBase
    {
        public Guid ReviewBadgeTemplateID { get; set; }
        public Guid ReviewID { get; set; }

        //Nav Props
        public Review Review { get; set; }
        public ReviewBadgeTemplate ReviewBadgeTemplate { get; set; }
    }
}