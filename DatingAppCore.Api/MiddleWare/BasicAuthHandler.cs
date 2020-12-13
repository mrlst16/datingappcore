using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace DatingAppCore.Api.MiddleWare
{

    public class BasicAuthOptions : AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; set; }
    }

    public class BasicAuthHandler : AuthenticationHandler<BasicAuthOptions>
    {
        public BasicAuthHandler(IOptionsMonitor<BasicAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock) { }

        IAuthorizationService _authorizationService;
        //ICrudRepo
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var service = new BasicAuthorizationService();
            var response = service.Authorize(this.Context.Request.Headers);
            if (response.Data)
            //THIS WORKS FOR SUCCESS!
            {
                
            }

            return AuthenticateResult.Fail(new Exception("401"));
        }
    }
}