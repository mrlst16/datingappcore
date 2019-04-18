using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using DatingAppCore.DTO;

namespace DatingAppCore.Repo.Members
{
    public class Photo : EntityBase
    {
        public Guid UserID { get; set; }
        public int Rank { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }

        public AccessLevel Access { get; set; } = AccessLevel.Public;
        //Nav Props
        public User User { get; set; }
    }
}
