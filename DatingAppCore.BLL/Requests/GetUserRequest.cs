using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Requests
{
    public class GetUserRequest
    {
        public Guid UserID { get; set; }
        public bool IncludeProfile { get; set; } = false;
        public bool IncludeMessages { get; set; } = false;
        public bool IncludeSwipes { get; set; } = false;
        public bool IncludePhotos { get; set; } = false;
        public bool IncludeReviews { get; set; } = false;
        public bool IncludePermissions { get; set; } = false;
    }
}
