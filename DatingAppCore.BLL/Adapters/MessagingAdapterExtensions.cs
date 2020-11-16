using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Repo.EF.Messaging;

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

        public static MessageDTO ToDto(this Message message)
        {
            return new MessageDTO()
            {
                ID = message.ID,
                From = message.SenderID,
                To = message.ReceiverID,
                Message = message.Content
            };
        }

        public static ConversationDTO ToDto(this Conversation entity)
        {
            if (entity == null) return null;
            return new ConversationDTO()
            {
                ID = entity.ID,
                User1ID = entity.User1ID,
                User2ID = entity.User2ID,
                Messages = entity.Messages?.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
