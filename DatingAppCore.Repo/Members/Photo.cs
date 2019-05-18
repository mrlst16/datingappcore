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
        public string Caption { get; set; }
        public PhotoAccessLevelEnum Access { get; set; } = PhotoAccessLevelEnum.Public;
        //Nav Props
        public User User { get; set; }
        public PhotoData Data { get; set; }
    }
}