using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.API.Services.Requests
{
    public class AuthorizationRequest
    {
        public Guid ClientID { get; set; }
        public string Data { get; set; }
    }
}