using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatingAppCore.BLL.Responses
{
    public class PhotoStreamResponse
    {
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
    }
}
