using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Reviewing
{
    public class UserReviewBadgeDTO : DtoBase
    {
        public ReviewBadgeTemplateDTO Template { get; set; }
        public Guid ReviewID { get; set; }
    }
}
