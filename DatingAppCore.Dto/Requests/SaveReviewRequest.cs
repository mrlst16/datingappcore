using DatingAppCore.Entities.Reviewing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class SaveReviewRequest
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public double Rating { get; set; }

        public ICollection<ReviewBadgeTemplate> Badges { get; set; }
    }
}
