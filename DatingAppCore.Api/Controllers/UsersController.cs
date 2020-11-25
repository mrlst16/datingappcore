using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Responses;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Entities.Members;
using DatingAppCore.Api.ServiceFactories.Interfaces;
using CommonCore.Models.Responses;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserServiceFactory<int> _userServiceFactory;

        private readonly ISetSettingsService _setSettingsService;
        private readonly ISetProfileService _setProfileService;
        private readonly ISetPhotosService _setPhotosService;
        private readonly ISaveFormFilesService _saveFormFilesService;
        private readonly IGetPhotoStreamService _getPhotoStreamService;
        private readonly IRecordUserLocationService _recordUserLocationService;

        public UsersController(
            IUserServiceFactory<int> userServiceFactory,
            ISetSettingsService setSettingsService,
            ISetProfileService setProfileService,
            ISetPhotosService setPhotosService,
            ISaveFormFilesService saveFormFilesService,
            IGetPhotoStreamService getPhotoStreamService,
            IRecordUserLocationService recordUserLocationService
            )
        {
            _userServiceFactory = userServiceFactory;
            _setSettingsService = setSettingsService;
            _setProfileService = setProfileService;
            _setPhotosService = setPhotosService;
            _saveFormFilesService = saveFormFilesService;
            _getPhotoStreamService = getPhotoStreamService;
            _recordUserLocationService = recordUserLocationService;
        }

        ///[Authorize(AuthenticationSchemes = "Basic")]
        [HttpGet("get_user")]
        public async Task<IActionResult> GetUser([FromQuery] Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty)
                return StatusCode(
                    400,
                    new SimpleResponse<User>()
                    {
                        Data = null,
                        Messages = new List<string>() {
                            "id must be provided"
                        }
                    }
                );

            var service = _userServiceFactory.GetUserService(1);

            var result = await service.Process(id.Value);
            return Ok(new SimpleResponse<User>()
            {
                Data = result,
                Messages = new List<string>() { "" },
                Sucess = true
            });
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
        public async Task<IActionResult> ViewImage(Guid userid, string filename)
        {
            var response = await _getPhotoStreamService.GetPhotoAsStream(new GetPhotoStreamRequest()
            {
                UserID = userid,
                FileName = filename
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