using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Requests
{
    public class PaginatedRequest
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 1000;
    }
}
