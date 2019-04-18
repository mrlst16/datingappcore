using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Clients
{
    public class ClientAuth : EntityBase
    {
        public Guid ClientID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Client Client { get; set; }
    }
}
