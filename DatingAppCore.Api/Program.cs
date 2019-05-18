using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonCore.IOC;
using CommonCore.Repo.Repository;
using CommonCore.Services.Interfaces;
using DatingApp.API.Services;
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
            builder.RegisterType<SavePhotoToFileService>().As<ISaveFormFilesService>();
            builder.RegisterType<SendMessageService>().As<ISendMessageService>();
            builder.RegisterType<SendReviewService>().As<ISendReviewService>();
            builder.RegisterType<SetPhotosService>().As<ISetPhotosService>();
            builder.RegisterType<GetPhotosFromFileService>().As<IGetPhotoStreamService>();
            builder.RegisterType<SetProfileService>().As<ISetProfileService>();
            builder.RegisterType<SetSettingsService>().As<ISetSettingsService>();
            builder.RegisterType<SwipeService>().As<ISwipeService>();
            builder.RegisterType<BasicAuthorizationService>().As<IAuthorizationService>();
            var container = builder.Build();

            KeyedDependencyResolver.InitDefault(new AutofacServiceProvider(container.BeginLifetimeScope()));
        }

        protected static void SetupDbConexts()
        {
            RepoCache.Initialize(typeof(DatingAppCore.Repo.AppContext));
        }
    }
}