using DatingAppCore.Repo.Messaging;
using DatingAppCore.Repo.Reviewing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.Repo.Matching;
using CommonCore.Repo.Entities;
using DatingAppCore.Dto;

namespace DatingAppCore.Repo.Members
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public Guid ClientID { get; set; }
        public string ExternalID { get; set; }
        public IDTypeEnum IdType { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime? Birthday { get; set; }


        //Nav Props
        public ICollection<Message> Inbox { get; set; }
        public ICollection<Message> Sent { get; set; }

        public ICollection<Swipe> SwipesSent { get; set; }
        public ICollection<Swipe> SwipesReceived { get; set; }

        public ICollection<Review> ReviewsSent { get; set; }
        public ICollection<Review> ReviewReceived { get; set; }

        public ICollection<UserProfileField> Profile { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<GrantedPermission> AsGrantee { get; set; }
        public ICollection<GrantedPermission> AsGrantor { get; set; }

    }
}
