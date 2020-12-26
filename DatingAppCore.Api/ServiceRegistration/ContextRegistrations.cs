using CommonCore.Interfaces.Repository;
using CommonCore2.Repository.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class ContextRegistrations
    {
        public static void RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICrudRepositoryFactory>(x =>
                new MongoDbCrudRepositoryFactory(
                    configuration.GetConnectionString("mongodb_connection")));

        }
    }
}
