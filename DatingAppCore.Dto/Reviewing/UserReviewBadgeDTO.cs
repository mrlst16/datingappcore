using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.DTO.Reviewing
{
    public class UserReviewBadgeDTO: DtoBase
    {
        public string Name { get; set; }
        public Guid ReviewID { get; set; }
    }
}
