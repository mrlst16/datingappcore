using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class LookupByUserIDRequest
    {
        public Guid UserID { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 1000;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
