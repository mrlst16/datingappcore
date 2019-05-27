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
using System.IO;
using CommonCore.Responses;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ILoginOrSignupService _loginOrSignupService;
        private readonly IGetUserService _getUserService;
        private readonly ISetSettingsService _setSettingsService;
        private readonly ISetProfileService _setProfileService;
        private readonly ISetPhotosService _setPhotosService;
        private readonly ISaveFormFilesService _saveFormFilesService;
        private readonly IGetPhotoStreamService _getPhotoStreamService;
        private readonly IRecordUserLocationService _recordUserLocationService;

        public UsersController(
            ILoginOrSignupService loginOrSignupService,
            IGetUserService getUserService,
            ISetSettingsService setSettingsService,
            ISetProfileService setProfileService,
            ISetPhotosService setPhotosService,
            ISaveFormFilesService saveFormFilesService,
            IGetPhotoStreamService getPhotoStreamService,
            IRecordUserLocationService recordUserLocationService
            )
        {
            _loginOrSignupService = loginOrSignupService;
            _getUserService = getUserService;
            _setSettingsService = setSettingsService;
            _setProfileService = setProfileService;
            _setPhotosService = setPhotosService;
            _saveFormFilesService = saveFormFilesService;
            _getPhotoStreamService = getPhotoStreamService;
            _recordUserLocationService = recordUserLocationService;
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
            var result = await _loginOrSignupService.LoginOrSignup(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("get_user")]
        public async Task<IActionResult> GetUser(GetUserRequest request)
        {
            var result = await _getUserService.GetUser(request);
            return Ok(JsonConvert.SerializeObject(result));
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_user_settings")]
        public async Task<IActionResult> SetUserSettings(SetPropertiesRequest request)
        {
            var result = await _setSettingsService.Set(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_user_profile")]
        public async Task<IActionResult> SetUserProfile(SetPropertiesRequest request)
        {
            var result = await _setProfileService.Set(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("set_photos")]
        public async Task<IActionResult> SetPhotos(SetPhotosRequest request)
        {
            var result = await _setPhotosService.Set(request);
            return Json(result);
        }


        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("upload_photo")]
        public async Task<IActionResult> UploadPhoto(List<IFormFile> files)
        {
            Response<bool> result =
                new Response<bool>()
                .IsUnSuccessful();

            if (Guid.TryParse(Request.Headers["userid"], out Guid userid))
            {
                result = await _saveFormFilesService.Save(new SaveFilesRequest()
                {
                    Files = files,
                    UserID = userid
                });
            }
            return Json(result);
        }

        [HttpGet("get_photo")]
        public async Task<IActionResult> ViewImage(Guid id)
        {
            var response = await _getPhotoStreamService.GetPhotoAsStream(new GetPhotoStreamRequest()
            {
                PhotoID = id
            });
            return File(response.Result.Stream, response.Result.ContentType);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("record_user_location")]
        public async Task<IActionResult> RecordUserLocation(UserLocation request)
        {
            var result = await _recordUserLocationService.Record(request);
            return Json(result);
        }
    }
}