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
using CommonCore.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Linq;

namespace DatingAppCore.Api.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<User> _userValidator;
        private readonly IValidator<UserSettings> _userSettingsValidator;
        private readonly IValidator<SetPhotosRequest> _setPhotosRequestValidator;
        private readonly IValidator<SetPropertiesRequest> _setPropertiesRequestValidator;

        public UsersController(
            IUserService userService,
            IValidator<User> userValidator,
            IValidator<UserSettings> userSettingsValidator,
            IValidator<SetPhotosRequest> setPhotosRequestValidator,
            IValidator<SetPropertiesRequest> setPropertiesRequestValidator
            )
        {
            _userService = userService;
            _userValidator = userValidator;
            _userSettingsValidator = userSettingsValidator;
            _setPhotosRequestValidator = setPhotosRequestValidator;
            _setPropertiesRequestValidator = setPropertiesRequestValidator;
        }

        [HttpGet("get_user")]
        public async Task<IActionResult> GetUser()
        {
            var username = User.Identity.Name;

            var result = await _userService.GetUser(username);

            return Ok(new ApiResponse<User>()
            {
                Data = result,
                SuccessMessage = $"User {username} found",
                FailureMessage = $"User {username} has not yet setup their profile",
                Sucess = result != null
            });
        }

        [HttpPost("add_user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.UserName = User?.Identity?.Name;
            
            ValidationResult validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());
            await _userService.AddUser(user);

            return Ok(new ApiResponse<User>()
            {
                Data = user,
                SuccessMessage = $"User added",
                Sucess = true
            });
        }

        [HttpPost("set_user")]
        public async Task<IActionResult> SetUser(UserSettings request)
        {
            var validationResult = _userSettingsValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var (success, result) = await _userService.SetUserSettings(request);
            if (success)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        [HttpPost("set_user_settings")]
        public async Task<IActionResult> SetUserSettings(UserSettings request)
        {
            var validationResult = _userSettingsValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var (success, result) = await _userService.SetUserSettings(request);
            if (success)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        [HttpPost("set_user_profile")]
        public async Task<IActionResult> SetUserProfile(SetPropertiesRequest request)
        {
            var validationResult = _setPropertiesRequestValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var result = await _userService.SetUserProperties(request);
            return Json(result);
        }

        [HttpPost("set_photos")]
        public async Task<IActionResult> SetPhotos(SetPhotosRequest request)
        {
            var validationResult = _setPhotosRequestValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var (success, result) = await _userService.SetUserPhotos(request);
            if (success)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }
    }
}
