using DatingAppCore.Api.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.MiddleWare
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            // Do logging or other work that doesn't write to the Response.
            try
            {
                ILogger logger = new ApiRequestLogger();
                logger.Log<HttpContext>(LogLevel.Information, new EventId(Guid.NewGuid().GetHashCode()), context, null, null);
            }
            catch (Exception e)
            {
            }
        }
    }
}
