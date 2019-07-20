using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api
{

    public class Conversation
    {
        public Guid ID { get; set; }
        public string ConnectionID { get; set; }
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
    }

    public class ChatHub : Hub
    {

        private List<Conversation> conversations
            = new List<Conversation>();

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
                return;
                var conversation = await LoginOrRegisterConversation(from, to);
                await Groups.AddToGroupAsync(Context.ConnectionId, conversation.ID.ToString());
                await Clients.Group(conversation.ID.ToString()).SendAsync($"RegisterComplete", from, conversation.ID.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Conversation> LoginOrRegisterConversation(string from, string to)
        {
            try
            {
                Conversation conversation = null;
                if (Guid.TryParse(from, out Guid fromID) && Guid.TryParse(from, out Guid toID))
                {
                    conversation = conversations
                        .FirstOrDefault(x =>
                            (x.User1ID == fromID && x.User2ID == toID)
                            || (x.User1ID == toID && x.User2ID == fromID)
                        );
                    if (conversation == null)
                    {
                        conversation = new Conversation()
                        {
                            ID = Guid.NewGuid(),
                            User1ID = fromID,
                            User2ID = toID
                        };
                        conversations.Add(conversation);
                    }
                }

                return conversation;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}