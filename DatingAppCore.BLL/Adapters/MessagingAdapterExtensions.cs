using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo;
using DatingAppCore.DTO.Messages;
using DatingAppCore.Repo.Messaging;

namespace DatingAppCore.BLL.Adapters
{
    public static class MessagingAdapterExtensions
    {
        public static Message ToEntity(this MessageDTO message)
        {
            return new Message()
            {
                ID = message.ID,
                LastUpdated = DateTime.UtcNow,
                CreateDate = DateTime.UtcNow,
                Content = message.Message,
                ReceiverID = message.To,
                SenderID = message.From
            }.EnsureID();
        }
    }
}
