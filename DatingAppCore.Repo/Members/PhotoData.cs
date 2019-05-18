using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Repo.Members
{
    public class PhotoData : EntityBase
    {
        public Guid PhotoID { get; set; }
        public Byte[] Data { get; set; }
        public string ContentType { get; set; }

        public Photo Photo { get; set; }
    }
}
