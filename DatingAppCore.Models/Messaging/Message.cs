using CommonCore.Repo.Entities;
using System;

namespace DatingAppCore.Entities.Messaging
{
    public class Message : EntityBase
    {
        public Guid ConversationID { get; set; }
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public string Content { get; set; }

    }
}
