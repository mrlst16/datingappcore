using Autofac;
using CommonCore.Responses;
using CommonCore.Services.Interfaces;
using DatingAppCore.Dto;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using DatingAppCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Test.Tests
{
    [TestClass]
    public class ServiceTests : TestClassBase
    {
        [TestMethod]
        public void TestAuthService()
        {
            var service = Container.Resolve<IAuthorizationService>();

        }

        [TestMethod]
        public async void LoginOrSignupTest()
        {
            var service = Container.Resolve<ILoginOrSignupService>();
            Response<LoginOrSignupResponse> response = await service.LoginOrSignup(
                new LoginOrSignupRequest()
                {
                    User = new Dto.Members.UserDTO()
                    {
                        ExternalID = "fb_0014",
                        IdType = IDTypeEnum.Facebook
                    }
                });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
            Assert.IsTrue(response.Result.User.ID != Guid.Empty);
        }

        [TestMethod]
        public async void FindPotentialMatchesTest()
        {
            var service = Container.Resolve<IPotentialMatchesService>();
            var response = await service.FindPotentialMatches(new FindMatchRequest()
            {
                UserID = Guid.Parse("")
            });
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
        }

        [TestMethod]
        public async void SetUserSettings()
        {
            ISetProfileService service = Container.Resolve<ISetProfileService>();
            var response = await service.Set(new SetPropertiesRequest()
            {

            });
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
        }

        [TestMethod]
        public void SetPhotos()
        {
            ISetPhotosService service = Container.Resolve<ISetPhotosService>();
            var response = service.Set(new SetPhotosRequest()
            {

            });
        }

        [TestMethod]
        public void TestingRepository()
        {
            string h = "h";

            h += "e";
        }
    }
}
