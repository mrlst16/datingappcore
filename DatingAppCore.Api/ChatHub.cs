using CommonCore.Responses;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Messages;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api
{
    public class ChatHub<TLookupConversationService, TSendMessageService> : Hub
        where TLookupConversationService : ILookupConversationService, new()
        where TSendMessageService : ISendMessageService, new()
    {
        public ChatHub()
        {
        }

        public async Task SendMessage(string from, string to, string message)
        {
            try
            {
                if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(to, out Guid toID))
                {
                    var conversation = await LoginOrRegisterConversation(fromID, toID);
                    await Clients.Group(conversation.ID.ToString()).SendAsync($"ReceiveMessage", from, to, message);
                    ISendMessageService sendMessageService = new TSendMessageService();
                    var response = await sendMessageService.Send(new MessageDTO()
                    {
                        From = fromID,
                        To = toID,
                        ID = Guid.NewGuid(),
                        Message = message
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RegisterConversation(string from, string to)
        {
            try
            {
                if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(to, out Guid toID))
                {
                    var conversation = await LoginOrRegisterConversation(fromID, toID);
                    await Groups.AddToGroupAsync(Context.ConnectionId, conversation.ID.ToString());
                    await Clients.Group(conversation.ID.ToString()).SendAsync($"RegisterComplete", conversation.ID.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UnRegisterConversation(string from, string to)
        {
            try
            {
                if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(to, out Guid toID))
                {
                    var conversation = await LoginOrRegisterConversation(fromID, toID);
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversation.ID.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<ConversationDTO> LoginOrRegisterConversation(Guid fromID, Guid toID)
        {
            ConversationDTO conversation = null;
            var lookupConversationService = new TLookupConversationService();
            Response<ConversationDTO> response = await lookupConversationService
                .Lookup(new Dto.Requests.GetConversationRequest()
                {
                    User1ID = fromID,
                    User2ID = toID
                });

            if (response.Sucess)
            {
                return response.Result;
            }

            return conversation;
        }
    }
}