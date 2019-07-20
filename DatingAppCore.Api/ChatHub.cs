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

    //public class Conversation
    //{
    //    public Guid ID { get; set; }
    //    public string ConnectionID { get; set; }
    //    public Guid User1ID { get; set; }
    //    public Guid User2ID { get; set; }
    //}

    public class ChatHub : Hub
    {
        protected class ConversationComparer : IEqualityComparer<ConversationDTO>
        {
            public bool Equals(ConversationDTO one, ConversationDTO two)
            {
                return
                    (
                        one.ID == two.ID
                        && one.ID != Guid.Empty
                        && two.ID != Guid.Empty
                    )
                    || (one.User1ID == two.User1ID && one.User2ID == two.User2ID)
                    || (one.User1ID == two.User2ID && one.User2ID == two.User1ID);
            }

            public int GetHashCode(ConversationDTO obj)
            {
                return obj.GetHashCode();
            }
        }

        private List<ConversationDTO> conversations
            = new List<ConversationDTO>();

        public ChatHub()
        {
        }

        public async Task SendMessageToGroup(string user, string message)
        {
            try
            {
                var conversation = conversations.Find(x => x.ConnectionID == Context.ConnectionId);
                await Clients.Group(conversation.ID.ToString()).SendAsync($"ReceiveMessage", user, message);
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
            if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(from, out Guid toID))
            {
                conversation = conversations.FirstOrDefault(
                    (x) => (x.User1ID == fromID && x.User2ID == toID)
                    || (x.User1ID == toID && x.User2ID == fromID)
                );
                if (conversation != null) return conversation;

                var lookupConversationService = new LookupConversationService();
                Response<ConversationDTO> response = await lookupConversationService.Lookup(new Dto.Requests.GetConversationRequest()
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