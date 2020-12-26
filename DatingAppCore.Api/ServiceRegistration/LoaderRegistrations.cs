using CommonCore.Interfaces.Loaders;
using CommonCore2.Loaders;
using DatingAppCore.BLL.Interfaces.Loaders;
using DatingAppCore.BLL.Loaders;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class LoaderRegistrations
    {
        public static void RegisterLoaders(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationLoader, AuthenticationLoader>();
            services.AddTransient<IAuthorizationTokenLoader, JWTTokenLoader>();
            services.AddTransient<IUserLoader, UserLoader>();
        }
    }
}
