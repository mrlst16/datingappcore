using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.MiddleWare
{
    public class BasicAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _policyName;

        public BasicAuthorizationMiddleware(RequestDelegate next, string policyName)
        {
            _next = next;
            _policyName = policyName;
        }

        public async Task Invoke(HttpContext httpContext, IAuthorizationService authorizationService)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            bool sucess = random.Next() % 2 == 0;
            if (!sucess)
            {
                await httpContext.ChallengeAsync();
                return;
            }

            await _next(httpContext);
        }
    }
}
