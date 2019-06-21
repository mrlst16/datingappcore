using CommonCore.Repo.Entities;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Messaging
{
    public class Message : EntityBase
    {
        public Guid ConversationID { get; set; }
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public string Content { get; set; }

        //Nav props
        public Conversation Conversation { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
