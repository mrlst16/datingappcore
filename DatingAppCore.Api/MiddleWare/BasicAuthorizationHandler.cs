using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.MiddleWare
{
    public class BasicAuthorizationHandler : AuthorizationHandler<BasicAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BasicAuthorizationRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {

                var service = Program.Container.Resolve<DatingApp.API.Services.Interfaces.IAuthorizationService>();
                var response = service.Authorize(mvcContext.HttpContext.Request.Headers);
                if (response.Result)
                    context.Succeed(requirement);
                else
                {
                    mvcContext.HttpContext.Response.StatusCode = 401;
                    //context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }
}
