using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Members
{
    public class MatchDTO : DtoBase
    {
        public Guid LeftID { get; set; }
        public Guid RightID { get; set; }
    }
}
