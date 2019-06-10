using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class SaveFilesRequest
    {
        public ICollection<IFormFile> Files { get; set; }
        public Guid UserID { get; set; }
    }
}
