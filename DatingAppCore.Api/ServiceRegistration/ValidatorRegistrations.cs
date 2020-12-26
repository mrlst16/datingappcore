using CommonCore.Models.Authentication;
using DatingAppCore.Api.Validators;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAppCore.Api.ServiceRegistration
{
    public static class ValidatorRegistrations
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PasswordRequest>, PasswordRequestValidator>();

            services.AddTransient<IValidator<User>, AddUserValidator>();
            services.AddTransient<IValidator<SetPhotosRequest>, SetPhotosRequestValidator>();
            services.AddTransient<IValidator<UserSettings>, UserSettingsValidator>();
            services.AddTransient<IValidator<SetPropertiesRequest>, SetPropertiesRequestValidator>();
        }
    }
}
