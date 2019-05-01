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
                new BLL.Signup.Requests.LoginOrSignupRequest() {
                    User = new DTO.Members.UserDTO()
                    {
                        ExternalID = "fb_0000",
                        IdType = DTO.IDTypeEnum.Facebook,
                        Photos = new List<DTO.Members.PhotoDTO>()
                        {
                            new DTO.Members.PhotoDTO()
                            {
                                Access = DTO.PhotoAccessLevelEnum.Public,
                                Caption = "Balls",
                                Rank = 0,
                                Url = "http://static.nfl.com/static/content/public/static/img/fantasy/transparent/200x200/BRA371156.png"
                            }
                        }
                    }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Sucess);
        }
    }
}
