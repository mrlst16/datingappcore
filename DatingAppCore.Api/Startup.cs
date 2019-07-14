using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonCore.IOC;
using CommonCore.Repo.Repository;
using DatingApp.API.Services;
using DatingAppCore.Api.Custom;
using DatingAppCore.Api.MiddleWare;
using DatingAppCore.BLL.Services;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DatingAppCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication("Basic").AddScheme<BasicAuthOptions, BasicAuthHandler>("Basic", null, options =>
            {

            });

            SetupDbConexts();
            var container = SetupIOC(services);
            var asp = new AutofacServiceProvider(container);
            KeyedDependencyResolver.InitDefault(asp);

            return asp;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware<RequestLogMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }

        private IContainer SetupIOC(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<GetUserService>().As<IGetUserService>();
            builder.RegisterType<LoginOrSignupService>().As<ILoginOrSignupService>();
            builder.RegisterType<PotentialMatchesService>().As<IPotentialMatchesService>();
            builder.RegisterType<SearchUsersService>().As<ISearchUsersService>();
            builder.RegisterType<SavePhotoToFileService>().As<ISaveFormFilesService>();
            builder.RegisterType<GetClientReviewBadgesService>().As<IGetClientReviewBadgesService>();
            builder.RegisterType<SendMessageService>().As<ISendMessageService>();
            builder.RegisterType<LookupConversationService>().As<ILookupConversationService>();
            builder.RegisterType<SendReviewService>().As<ISendReviewService>();
            builder.RegisterType<GetReviewService>().As<IGetReviewService>();
            builder.RegisterType<SetPhotosUpdateOrderOnlyService>().As<ISetPhotosService>();
            builder.RegisterType<GetPhotosFromFileServiceV2>().As<IGetPhotoStreamService>();
            builder.RegisterType<SetProfileService>().As<ISetProfileService>();
            builder.RegisterType<SetSettingsService>().As<ISetSettingsService>();
            builder.RegisterType<SwipeService>().As<ISwipeService>();
            builder.RegisterType<GetMatchesService>().As<IGetMatchesService>();
            builder.RegisterType<RecordUserLocationService>().As<IRecordUserLocationService>();

            builder.RegisterType<ApiRequestLogger>().As<ILogger>();
            builder.RegisterType<BasicAuthorizationService>().As<CommonCore.Services.Interfaces.IAuthorizationService>();
            var container = builder.Build();
            return container;
        }

        private static void SetupDbConexts()
        {
            RepoCache.Initialize(typeof(DatingAppCore.Repo.AppContext));
        }
    }
}
