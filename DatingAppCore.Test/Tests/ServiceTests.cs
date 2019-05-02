using Autofac;
using CommonCore.Responses;
using DatingApp.API.Services.Interfaces;
using DatingAppCore.BLL.Responses;
using DatingAppCore.BLL.Services.Interfaces;
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
        public void LoginOrSignupTest()
        {
            var service = Container.Resolve<ILoginOrSignupService>();
            Response<LoginOrSignupResponse> response = service.LoginOrSignup(
                new BLL.Signup.Requests.LoginOrSignupRequest()
                {
                    User = new DTO.Members.UserDTO()
                    {
                        ExternalID = "fb_0014",
                        IdType = DTO.IDTypeEnum.Facebook
                    }
                });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
            Assert.IsTrue(response.Result.User.ID != Guid.Empty);
        }

        [TestMethod]
        public void FindPotentialMatchesTest()
        {
            var service = Container.Resolve<IPotentialMatchesService>();
            var response = service.FindPotentialMatches(new BLL.Requests.FindMatchRequest()
            {
                UserID = Guid.Parse("")
            });
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
        }

        [TestMethod]
        public void SetUserSettings()
        {
            ISetPropertiesService service = Container.Resolve<ISetPropertiesService>();
            var response = service.Set(new BLL.Requests.SetPropertiesRequest()
            {

            });
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
        }

        [TestMethod]
        public void SetPhotos()
        {
            ISetPhotosService service = Container.Resolve<ISetPhotosService>();
            var response = service.Set(new BLL.Requests.SetPhotosRequest()
            {

            });
        }
    }
}
