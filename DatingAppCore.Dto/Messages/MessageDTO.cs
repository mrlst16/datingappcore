using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO.Messages
{
    public class MessageDTO : DtoBase
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Message { get; set; }
    }
}
