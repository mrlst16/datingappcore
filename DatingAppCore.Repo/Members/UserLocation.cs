using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;

namespace DatingAppCore.Repo.Members
{
    public class UserLocation : EntityBase
    {
        public Guid UserID { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
