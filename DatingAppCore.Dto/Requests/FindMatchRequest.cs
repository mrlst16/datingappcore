using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.DTO;

namespace DatingAppCore.Dto.Requests
{
    public class FindMatchRequest : PaginatedRequest
    {
        public Guid UserID { get; set; }
    }
}
