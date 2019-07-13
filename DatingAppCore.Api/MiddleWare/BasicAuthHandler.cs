using Autofac;
using CommonCore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CommonCore.IOC;

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

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var service = KeyedDependencyResolver.GetDefaultService<IAuthorizationService>();
            var response = service.Authorize(this.Context.Request.Headers);
            if (response.Result)
                //THIS WORKS FOR SUCCESS!
                return Task.FromResult(
                    AuthenticateResult.Success(
                       new AuthenticationTicket(
                           new ClaimsPrincipal(new ClaimsIdentity("Basic")
                           {
                           }),
                           new AuthenticationProperties(),
                           this.Scheme.Name)));

            return Task.FromResult(AuthenticateResult.Fail(new Exception("401")));
        }
    }
}