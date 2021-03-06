﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using DatingAppCore.Entities.Enum;

namespace DatingAppCore.Entities.Members
{
    public class Photo : EntityBase
    {
        public Guid UserID { get; set; }
        public int Rank { get; set; }
        public string Caption { get; set; }
        public string FileName { get; set; }
        public AccessLevelEnum Access { get; set; } = AccessLevelEnum.Public;
        public string ContentType { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Photo)) return false;
            var photo = obj as Photo;
            if (this.ID == Guid.Empty && photo.ID == Guid.Empty) return false;

            return (this.ID == photo.ID) || this.UserID == photo.UserID
                && this.FileName == this.FileName;
        }

        public static bool operator ==(Photo one, Photo two) => one.Equals(two);
        public static bool operator !=(Photo one, Photo two) => !one.Equals(two);
    }
}