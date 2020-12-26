using CommonCore.Interfaces.Services;
using CommonCore2.Services;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
