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
        public string FileName { get; set; }
        public PhotoAccessLevelEnum Access { get; set; } = PhotoAccessLevelEnum.Public;
        public string ContentType { get; set; }

        //Nav Props
        public User User { get; set; }
        public PhotoData Data { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Photo)) return false;
            var photo = obj as Photo;

            return this.UserID == photo.UserID
                && this.FileName == this.FileName;
        }
    }
}