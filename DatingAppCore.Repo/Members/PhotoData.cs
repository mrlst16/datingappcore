using CommonCore.Repo.Entities;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Repo.EF.Members
{
    public class PhotoData : EntityBase
    {
        public Guid PhotoID { get; set; }
        public Byte[] Data { get; set; }

        public Photo Photo { get; set; }
    }
}
