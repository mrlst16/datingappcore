using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using DatingAppCore.Repo.EF.Members;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.Repo.EF.Matching
{
    public class Swipe : EntityBase
    {
        public Guid UserFromID { get; set; }
        public Guid UserToID { get; set; }
        public bool IsLike { get; set; }

        public User UserFrom { get; set; }
        public User UserTo { get; set; }
    }
}
