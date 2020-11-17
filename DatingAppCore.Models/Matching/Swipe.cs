using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using DatingAppCore.Entities.Members;

namespace DatingAppCore.Entities.Matching
{
    public class Swipe : EntityBase
    {
        public Guid UserFromID { get; set; }
        public Guid UserToID { get; set; }
        public bool IsLike { get; set; }
    }
}
