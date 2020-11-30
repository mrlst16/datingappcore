using CommonCore.Repo.Entities;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Entities.Matching
{
    public class Match : EntityBase
    {
        public Guid Swiper { get; set; }
        public Guid Swipee { get; set; }
    }
}
