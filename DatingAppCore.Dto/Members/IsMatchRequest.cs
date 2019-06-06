using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Members
{
    public class IsMatchRequest
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
    }
}
