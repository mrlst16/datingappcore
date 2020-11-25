using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.Repo.EF.Clients;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.Repo.Configuration
{
    public class Config_Clients
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<Client>().ToTable("Clients");
            mb.Entity<ClientAuth>().ToTable("ClientAuths");

            mb.Entity<Client>().HasKey(x => x.ID);
            mb.Entity<ClientAuth>().HasKey(x => x.ID);
        }
    }
}
