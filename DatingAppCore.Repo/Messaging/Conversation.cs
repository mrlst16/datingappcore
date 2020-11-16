using System;
using System.Collections.Generic;
using System.Text;
using CommonCore.Repo.Entities;
using DatingAppCore.Repo.EF.Members;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.Repo.EF.Messaging
{
    public class Conversation : EntityBase
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }

        public List<Message> Messages { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Conversation conversation)
            {
                return AreEqual(conversation, this);
            }
            return false;
        }

        public static bool AreEqual(Conversation one, Conversation two)
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

        public static bool AreEqual(Conversation conversation, Guid user1, Guid user2)
        {
            return
                    (conversation.User1ID == user1 && conversation.User2ID == user2)
                    || (conversation.User1ID == user2 && conversation.User2ID == user1);
        }
    }
}