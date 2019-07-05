using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class GetPhotoStreamRequest
    {
        public Guid PhotoID { get; set; }
        public Guid UserID { get; set; }
        public string FileName { get; set; }
    }
}
