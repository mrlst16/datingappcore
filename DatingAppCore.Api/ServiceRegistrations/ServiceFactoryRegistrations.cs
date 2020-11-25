using DatingAppCore.Api.ServiceFactories;
using DatingAppCore.Api.ServiceFactories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistrations
{
    public static class ServiceFactoryRegistrations
    {
        public static void RegisterServiceFactories(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddTransient<IUserServiceFactory<int>, UserServiceFactory>();
        }
    }
}
