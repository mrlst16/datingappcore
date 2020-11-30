using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;

namespace DatingAppCore.Dto.Requests
{
    public class FindMatchesRequest : PaginatedRequest
    {
        public Guid UserID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SurfaceRadius { get; set; }
        public IEnumerable<Guid> AlreadyMatched { get; set; }
    }
}
