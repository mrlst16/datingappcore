using CommonCore.Repo.Entities;
using DatingAppCore.Repo.EF.Members;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.EF.Matching
{
    public class Match : EntityBase
    {
        public Guid LeftID { get; set; }
        public Guid RightID { get; set; }

        //Nav Props
        public User Left { get; set; }
        public User Right { get; set; }
    }
}
