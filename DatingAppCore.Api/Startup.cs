using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Autofac;
using CommonCore.IOC;
using CommonCore.Repo.Repository;
using DatingApp.API.Services;
using DatingAppCore.Api.Custom;
using DatingAppCore.Api.MiddleWare;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication("Basic").AddScheme<BasicAuthOptions, BasicAuthHandler>("Basic", null, options =>
            {

            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
                options.KnownProxies.Add(IPAddress.Parse("127.0.0.1"));
            });

            //IXmlEncryptor encryptor = new NullXmlEncryptor();
            //IXmlRepository xmlRepository = new FileSystemXmlRepository(
            //    new DirectoryInfo(Directory.GetCurrentDirectory()),
            //    new LoggerFactory()
            //);

            //services.Configure<KeyManagementOptions>(options =>
            //{
            //    options.XmlEncryptor = encryptor;
            //    options.XmlRepository = xmlRepository;
            //}
            //);

            services.AddSignalR();

            SetupDbContexts();
            SetupIOC(services);
            var result = services.BuildServiceProvider();
            KeyedDependencyResolver.InitDefault(result);
            return result;
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
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3000", "https://supercooldatingapp.com")
                .AllowCredentials());

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub<LookupConversationService, SendMessageService>>("/chatHub");
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
            });

            

            app.UseMiddleware<RequestLogMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }

        private void SetupIOC(IServiceCollection services)
        {
            services.AddTransient<IGetUserService, GetUserService>();
            services.AddTransient<ILoginOrSignupService, LoginOrSignupService>();
            services.AddTransient<IPotentialMatchesService, PotentialMatchesServiceV2>();
            services.AddTransient<ISearchUsersService, SearchUsersService>();
            services.AddTransient<ISaveFormFilesService, SavePhotoToFileService>();
            services.AddTransient<IGetClientReviewBadgesService, GetClientReviewBadgesService>();
            services.AddTransient<ISendMessageService, SendMessageService>();
            services.AddTransient<ILookupConversationService, LookupConversationService>();
            services.AddTransient<ISendReviewService, SendReviewService>();
            services.AddTransient<IGetReviewService, GetReviewService>();
            services.AddTransient<ISetPhotosService, SetPhotosUpdateOrderOnlyService>();
            services.AddTransient<IGetPhotoStreamService, GetPhotosFromFileServiceV2>();
            services.AddTransient<ISetProfileService, SetProfileService>();
            services.AddTransient<ISetSettingsService, SetSettingsService>();
            services.AddTransient<ISwipeService, SwipeService>();
            services.AddTransient<IGetMatchesService, GetMatchesService>();
            services.AddTransient<IRecordUserLocationService, RecordUserLocationService>();
        }

        private static void SetupDbContexts()
        {
            RepoCache.Initialize(typeof(DatingAppCore.Repo.EF.AppContext));
        }
    }
}
