using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Entities.Members
{
    public class PhotoData : EntityBase
    {
        public Guid PhotoID { get; set; }
        public Byte[] Data { get; set; }

        public Photo Photo { get; set; }
    }
}
