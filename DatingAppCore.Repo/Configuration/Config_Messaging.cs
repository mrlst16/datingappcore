using DatingAppCore.Repo.EF.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Configuration
{
    public static class Config_Messaging
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<Conversation>().ToTable("Conversations");
            mb.Entity<Message>().ToTable("Messages");

            mb.Entity<Conversation>().HasKey(x => x.ID);
            mb.Entity<Message>().HasKey(x => x.ID);

            mb.Entity<Conversation>()
                .HasMany<Message>(x => x.Messages)
                .WithOne(x => x.Conversation)
                .HasForeignKey(x => x.ConversationID);
        }
    }
}
