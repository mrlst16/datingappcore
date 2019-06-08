using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Messages
{
    public class LookupByUserIDRequest
    {
        public Guid UserID { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
