using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
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
            CreateWebHostBuilder(args).Build().Run();
            SetupIOC();
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
            builder.RegisterType<SetPropertiesService>().As<ISetPropertiesService>();
            builder.RegisterType<SwipeService>().As<ISwipeService>();
            Container = builder.Build();
        }
    }
}