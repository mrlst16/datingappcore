using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class LoggerRegistrations
    {
        public static void RegisterLoggers(this IServiceCollection services)
        {
            services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
        }
    }
}
