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

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly ISendReviewService _sendReviewService;

        public ReviewsController(ISendReviewService sendReviewService)
        {
            _sendReviewService = sendReviewService;
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("get_client_badges")]
        public async Task<IActionResult> GetClientBadges(ReviewDTO request)
        {
            var result = await _sendReviewService.Send(request);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(ReviewDTO request)
        {
            var result = await _sendReviewService.Send(request);
            return Ok(result);
        }
    }
}