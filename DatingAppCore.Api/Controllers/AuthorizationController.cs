using CommonCore.Interfaces.Repository;
using CommonCore.Interfaces.Services;
using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using CommonCore2.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IValidator<PasswordRequest> _passwordRequestValidator;

        public AuthorizationController(
            IAuthenticationService authenticationService,
            IValidator<PasswordRequest> passwordRequestValidator
            )
        {
            _authenticationService = authenticationService;
            _passwordRequestValidator = passwordRequestValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PasswordRequest request)
        {
            var validationResult = _passwordRequestValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var data = await _authenticationService.SetupPassword(request);

            var response = new ApiResponse<bool>()
            {
                SuccessMessage = $"Successfully registered user {request}",
                FailureMessage = $"Failed to register user {request}",
                Sucess = data.Sucess
            };
            return StatusCode(200, response);
        }

        [HttpPost("get_token")]
        public async Task<IActionResult> GetToken([FromBody] PasswordRequest request)
        {
            var validationResult = _passwordRequestValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            var data = await _authenticationService.Authenticate(request);

            var response = new ApiResponse<string>()
            {
                Data = data.Data,
                SuccessMessage = $"Successfully logged in user {request}",
                FailureMessage = $"Failed to log in user {request}",
                Sucess = data.Sucess
            };
            return StatusCode(200, response);
        }
    }
}
