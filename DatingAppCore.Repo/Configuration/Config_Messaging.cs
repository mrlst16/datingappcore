using DatingAppCore.Repo.Messaging;
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
            mb.Entity<Message>().ToTable("Messages");

            mb.Entity<Message>().HasKey(x => x.ID);


        }
    }
}
