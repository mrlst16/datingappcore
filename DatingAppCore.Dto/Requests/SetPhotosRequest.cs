using DatingAppCore.Dto.Members;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;

namespace DatingAppCore.Dto.Requests
{
    public class SetPhotosRequest
    {
        public Guid UserID { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
