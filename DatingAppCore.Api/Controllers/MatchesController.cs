using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Matching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {
        private readonly IPotentialMatchesService _potentialMatchesService;
        private readonly ISwipeService _swipeService;

        public MatchesController(
            IPotentialMatchesService potentialMatchesService, 
            ISwipeService swipeService)
        {
            _potentialMatchesService = potentialMatchesService;
            _swipeService = swipeService;
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("potential_matches")]
        public async Task<IActionResult> PotentialMatches(FindMatchRequest request)
        {
            var result = await _potentialMatchesService.FindPotentialMatches(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("swipe")]
        public async Task<IActionResult> Swipe(SwipeDTO request)
        {
            var result = await _swipeService.Swipe(request);
            return Json(result);
        }
    }
}