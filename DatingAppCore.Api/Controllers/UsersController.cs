using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DatingAppCore.Api.Security;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.BLL.Signup.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [Authorization]
        public async Task<string> LoginOrSignup(LoginOrSignupRequest request)
        {
            var service = Program.Container.Resolve<ILoginOrSignupService>();
            var result = service.LoginOrSignup(request);
            return JsonConvert.SerializeObject(result);
        }

        [Authorization]
        public async Task<string> GetUser(GetUserRequest request)
        {
            IGetUserService service = Program.Container.Resolve<IGetUserService>();
            var result = service.GetUser(request);
            return JsonConvert.SerializeObject(result);
        }

        [Authorization]
        public async Task<string> SetUserSettings(SetPropertiesRequest request)
        {
            ISetPropertiesService service = Program.Container.Resolve<ISetPropertiesService>();
            var result = service.Set(request);
            return JsonConvert.SerializeObject(result);
        }

        [Authorization]
        public async Task<string> SetPhotos(SetPhotosRequest request)
        {
            ISetPhotosService service = Program.Container.Resolve<ISetPhotosService>();
            var result = service.Set(request);
            return JsonConvert.SerializeObject(result);
        }
    }
}