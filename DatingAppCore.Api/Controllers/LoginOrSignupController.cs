using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCore.Models.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginOrSignupController : Controller
    {


        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("login_or_signup")]
        public async Task<IActionResult> LoginOrSignup([FromHeader(Name = "")] Guid clientId, [FromBody] LoginOrSignupRequest request)
        {
            SimpleResponse<LoginOrSignupRequest> response =
                new SimpleResponse<LoginOrSignupRequest>();

            return null;
            //SimpleResponse<LoginOrSignupResponse> response = new SimpleResponse<LoginOrSignupResponse>();

            ////SimpleResponse<LoginOrSignupResponse> result = new SimpleResponse<LoginOrSignupResponse>();
            //if (Guid.TryParse(Request.Headers["ClientID"], out Guid clientId))
            //{
            //    request.User.ClientID = clientId;
            //    result = await _loginServiceFactory.LoginOrSignupService(1).Process(request);
            //}
            //return Json(result);
        }
    }
}
