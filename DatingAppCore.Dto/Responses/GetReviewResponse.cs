using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Responses
{
    public class BadgeAndCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class GetReviewResponse
    {
        public IEnumerable<BadgeAndCount> BadgesTable { get; set; }
    }
}
