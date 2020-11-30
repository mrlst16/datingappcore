using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatingAppCore.Entities.Members;
using FluentValidation;
using FluentValidation.Results;
using CommonCore.Models.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using CommonCore.Extensions;
using CommonCore.Api.Extensions;

namespace DatingAppCore.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Basic")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<User> _userValidator;

        public UsersController(
            IUserService userService,
            IValidator<User> userValidator
            )
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpGet("get_user")]
        public async Task<IActionResult> GetUser([FromQuery] Guid? id)
        {
            if (!id.HasValue || id.Value == Guid.Empty)
                return StatusCode(
                    400,
                    new SimpleResponse<User>()
                    {
                        Data = null,
                        FailureMessage = "id must be provided"
                    }
                );

            var result = await _userService.GetUser(id.Value);

            return Ok(new SimpleResponse<User>()
            {
                Data = result,
                SuccessMessage = $"User {id} found",
                Sucess = true
            });
        }

        [HttpPost("add_user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            ValidationResult validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());
            await _userService.AddUser(user);

            return Ok(new SimpleResponse<User>()
            {
                Data = user,
                SuccessMessage = $"User added",
                Sucess = true
            });
        }

        [HttpPost("set_user_settings")]
        public async Task<IActionResult> SetUserSettings(UserSettings request)
        {
            var result = await _userService.SetUserSettings(request);
            return Json(result);
        }

        [HttpPost("set_user_profile")]
        public async Task<IActionResult> SetUserProfile(SetPropertiesRequest request)
        {
            var result = await _userService.SetUserProperties(request);
            return Json(result);
        }

        [HttpPost("set_photos")]
        public async Task<IActionResult> SetPhotos(SetPhotosRequest request)
        {
            var result = await _userService.SetUserPhotos(request);
            return Json(result);
        }

        [HttpPost("upload_photo")]
        public async Task<IActionResult> UploadPhoto(List<IFormFile> files)
        {
            //if (Guid.TryParse(Request.Headers["userid"], out Guid userid))
            //{
            //    result = await _saveFormFilesService.Save(new SaveFilesRequest()
            //    {
            //        Files = files,
            //        UserID = userid
            //    });
            //}
            return Json(null);
        }

    }
}