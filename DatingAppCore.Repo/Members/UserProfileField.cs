using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Members
{
    public class UserProfileField : EntityBase
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsSetting { get; set; } = false;
        
        //Nav Props
        public User User { get; set; }
    }
}
