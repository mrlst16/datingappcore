using Autofac;
using CommonCore.Repo.Repository;
using CommonCore.Services.Interfaces;
using DatingApp.API.Services;
using DatingAppCore.BLL.Services;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Test.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Test.Helpers
{
    public class TestSetup
    {

        public TestSetup SetupIOC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GetUserService>().As<IGetUserService>();
            builder.RegisterType<LoginOrSignupService>().As<ILoginOrSignupService>();
            builder.RegisterType<PotentialMatchesService>().As<IPotentialMatchesService>();
            builder.RegisterType<SendMessageService>().As<ISendMessageService>();
            builder.RegisterType<SendReviewService>().As<ISendReviewService>();
            builder.RegisterType<SetPhotosService>().As<ISetPhotosService>();
            builder.RegisterType<SetPropertiesService>().As<ISetProfileService>();
            builder.RegisterType<SwipeService>().As<ISwipeService>();
            builder.RegisterType<BasicAuthorizationService>().As<IAuthorizationService>();
            TestClassBase.Container = builder.Build();
            return this;
        }

        public TestSetup InitializeRepository()
        {
            RepoCache.Initialize(typeof(DatingAppCore.Repo.AppContext));
            return this;
        }
    }
}
