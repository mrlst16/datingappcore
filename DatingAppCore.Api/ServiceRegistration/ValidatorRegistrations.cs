using DatingAppCore.Api.Validators;
using DatingAppCore.Entities.Members;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class ValidatorRegistrations
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<User>, AddUserValidator>();

        }
    }
}
