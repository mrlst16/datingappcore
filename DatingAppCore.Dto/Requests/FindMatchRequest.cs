using DatingAppCore.Entities.Members;
using System;

namespace DatingAppCore.Dto.Requests
{
    public class FindMatchRequest : PaginatedRequest
    {
        public Guid UserID { get; set; }
        public UserSettings Settings { get; set; }
        public UserPreferences UserPreferences { get; set; }
    }
}
