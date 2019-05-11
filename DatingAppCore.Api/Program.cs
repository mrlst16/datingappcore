using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CommonCore.Repo.Repository;
using DatingApp.API.Services;
using DatingApp.API.Services.Interfaces;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatingAppCore.Api
{
    public class Program
    {

        public static IContainer Container { get; protected set; }

        public static void Main(string[] args)
        {
            SetupIOC();
            SetupDbConexts();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        protected static void SetupIOC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GetUserService>().As<IGetUserService>();
            builder.RegisterType<LoginOrSignupService>().As<ILoginOrSignupService>();
            builder.RegisterType<PotentialMatchesService>().As<IPotentialMatchesService>();
            builder.RegisterType<SendMessageService>().As<ISendMessageService>();
            builder.RegisterType<SendReviewService>().As<ISendReviewService>();
            builder.RegisterType<SetPhotosService>().As<ISetPhotosService>();
            builder.RegisterType<SetProfileService>().As<ISetProfileService>();
            builder.RegisterType<SetSettingsService>().As<ISetSettingsService>();
            builder.RegisterType<SwipeService>().As<ISwipeService>();
            builder.RegisterType<BasicAuthorizationService>().As<IAuthorizationService>();
            Container = builder.Build();
        }

        protected static void SetupDbConexts()
        {
            RepoCache.Initialize(typeof(DatingAppCore.Repo.AppContext));
        }
    }
}