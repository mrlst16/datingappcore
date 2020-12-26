using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingAppCore.Api.MiddleWare
{
    public class JWTAuthorizationHandler : AuthorizationHandler<JWTAuthorizationRequirement>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, JWTAuthorizationRequirement requirement)
        {
            if (string.IsNullOrWhiteSpace(context?.User?.Identity?.Name))
            {
                context.Fail();
                return;
            }
            context.Succeed(requirement);
        }
    }

    public class JWTAuthorizationRequirement : IAuthorizationRequirement
    {
    }
}
