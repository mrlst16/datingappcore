using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;
using DatingAppCore.Interfaces;
using DatingAppCore.Dto.Reviewing;
using CommonCore.Responses;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private const string NO_BADGES_SELECTED_MESSAGE = "No badges selected.";

        private readonly ISendReviewService _sendReviewService;
        private readonly IGetClientReviewBadgesService _getClientReviewBadgesService;
        public ReviewsController(
            ISendReviewService sendReviewService,
            IGetClientReviewBadgesService getClientReviewBadgesService
            )
        {
            _sendReviewService = sendReviewService;
            _getClientReviewBadgesService = getClientReviewBadgesService;
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpGet("get_client_badges")]
        public async Task<IActionResult> GetClientBadges()
        {
            if (Guid.TryParse(Request.Headers["ClientID"], out Guid clientID))
            {
                var response = _getClientReviewBadgesService.GetClientReviewBadges(clientID);
                return Ok(response);
            }
            return BadRequest("Client Guid could not be parsed");
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(ReviewDTO request)
        {
            if (!request.Badges.Any())
            {
                return BadRequest(
                        new Response<bool>()
                            .WithException(new Exception(NO_BADGES_SELECTED_MESSAGE))
                    );
            }
            var result = await _sendReviewService.Send(request);
            return Ok(result);
        }
    }
}