using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.BLL.Signup.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CommonCore.IOC;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CommonCore.Mvc.Controller.CommonCoreControllerBase
    {

        public UsersController() : base()
        {

        }

        [HttpPost]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            var auth = Request.Headers["Authorization"];
            return Json(new { Balls = "Hairy", Auth = auth });
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("ping2")]
        public async Task<IActionResult> Ping2()
        {
            var auth = Request.Headers["Authorization"];
            return Json(new { Balls = "Hairy", Auth = auth });
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("login_or_signup")]
        public async Task<IActionResult> LoginOrSignup(LoginOrSignupRequest request)
        {
            var service = ServiceProvider.GetService<ILoginOrSignupService>();
            var result = await service.LoginOrSignup(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("get_user")]
        public async Task<IActionResult> GetUser(GetUserRequest request)
        {
            IGetUserService service = ServiceProvider.GetService<IGetUserService>();
            var result = await service.GetUser(request);
            return Ok(JsonConvert.SerializeObject(result));
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_user_settings")]
        public async Task<IActionResult> SetUserSettings(SetPropertiesRequest request)
        {
            var service = ServiceProvider.GetService<ISetSettingsService>();
            var result = await service.Set(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_user_profile")]
        public async Task<IActionResult> SetUserProfile(SetPropertiesRequest request)
        {
            ISetProfileService service = ServiceProvider.GetService<ISetProfileService>();
            var result = await service.Set(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_photos")]
        public async Task<IActionResult> SetPhotos(SetPhotosRequest request)
        {
            ISetPhotosService service = ServiceProvider.GetService<ISetPhotosService>();
            var result = await service.Set(request);
            return Json(result);
        }
    }
}