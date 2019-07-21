using CommonCore.Responses;
using DatingAppCore.BLL.Services;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
        }

        public async Task SendMessage(string from, string to, string message)
        {
            try
            {
                var conversation = await LoginOrRegisterConversation(from, to);
                await Clients.Group(conversation.ID.ToString()).SendAsync($"ReceiveMessage", from, to, message);
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
                var conversation = await LoginOrRegisterConversation(from, to);
                await Groups.AddToGroupAsync(Context.ConnectionId, conversation.ID.ToString());
                await Clients.Group(conversation.ID.ToString()).SendAsync($"RegisterComplete", from, conversation.ID.ToString());
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
                var conversation = await LoginOrRegisterConversation(from, to);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversation.ID.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<ConversationDTO> LoginOrRegisterConversation(string from, string to)
        {
            ConversationDTO conversation = null;
            if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(to, out Guid toID))
            {
                var lookupConversationService = new LookupConversationService();
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
            }

            return conversation;
        }
    }
}