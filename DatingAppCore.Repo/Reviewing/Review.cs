using CommonCore.Repo.Entities;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Reviewing
{
    public class Review : EntityBase
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public double Rating { get; set; }

        //Nav Props
        public User Sender { get; set; }
        public User Reciever { get; set; }

        public ICollection<UserReviewBadge> Badges { get; set; }
    }
}
