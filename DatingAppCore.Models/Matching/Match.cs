using CommonCore.Repo.Entities;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Models
{
    public class Match : EntityBase
    {
        public Guid LeftID { get; set; }
        public Guid RightID { get; set; }
    }
}
