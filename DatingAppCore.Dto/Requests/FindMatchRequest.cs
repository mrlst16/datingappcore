using System;

namespace DatingAppCore.Dto.Requests
{
    public class FindMatchRequest : PaginatedRequest
    {
        public Guid UserID { get; set; }
    }
}
