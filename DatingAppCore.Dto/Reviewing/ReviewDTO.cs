using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Reviewing
{
    public class ReviewDTO : DtoBase
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public double Rating { get; set; }

        public ICollection<UserReviewBadgeDTO> Badges { get; set; }
    }
}
