using DatingAppCore.Dto.Members;
using System;
using System.Collections.Generic;

namespace DatingAppCore.Dto.Requests
{
    public class SetPhotosRequest
    {
        public Guid UserID { get; set; }
        public List<PhotoDTO> Photos { get; set; }
    }
}
