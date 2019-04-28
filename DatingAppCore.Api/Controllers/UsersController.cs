using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
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
    public class UsersController : CommonCore.Mvc.Controller.CommonCoreControllerBase
    {

        public UsersController() : base(Program.Container)
        {

        }

        [HttpPost]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            var auth = Request.Headers["Authorization"];
            return Json(new { Balls = "Hairy", Auth = auth });
        }

        [HttpPost]
        public async Task<IActionResult> LoginOrSignup(LoginOrSignupRequest request)
        {
            return await CallWithAuthAsync(() =>
            {
                var service = Program.Container.Resolve<ILoginOrSignupService>();
                var result = service.LoginOrSignup(request);
                return Json(result);
            });
        }

        [HttpPost]
        [Route("get_user")]
        public async Task<IActionResult> GetUser(GetUserRequest request)
        {
            return await CallWithAuthAsync(() =>
            {
                IGetUserService service = Program.Container.Resolve<IGetUserService>();
                var result = service.GetUser(request);
                return Ok(JsonConvert.SerializeObject(result));
            });
        }

        [HttpPost]
        public async Task<IActionResult> SetUserSettings(SetPropertiesRequest request)
        {
            return await CallWithAuthAsync(() =>
            {
                ISetPropertiesService service = Program.Container.Resolve<ISetPropertiesService>();
                var result = service.Set(request);
                return Json(result);
            });
        }

        [HttpPost]
        public async Task<IActionResult> SetPhotos(SetPhotosRequest request)
        {
            return await CallWithAuthAsync(() =>
            {
                ISetPhotosService service = Program.Container.Resolve<ISetPhotosService>();
                var result = service.Set(request);
                return Json(result);
            });
        }
    }
}