﻿using System;
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
using DatingAppCore.Dto.Members;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {
        private readonly IPotentialMatchesService _potentialMatchesService;
        private readonly ISwipeService _swipeService;
        private readonly IGetMatchesService _getMatchesService;

        public MatchesController(
            IPotentialMatchesService potentialMatchesService, 
            ISwipeService swipeService,
            IGetMatchesService getMatchesService)
        {
            _potentialMatchesService = potentialMatchesService;
            _swipeService = swipeService;
            _getMatchesService = getMatchesService;
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

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("matches")]
        public async Task<IActionResult> Matches(MatchDTO reques)
        {
            var result = await _getMatchesService.GetMatches(reques.UserID);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("is_match")]
        public async Task<IActionResult> IsMatch(IsMatchRequest request)
        {
            var result = await _getMatchesService.IsMatch(request.User1ID, request.User2ID);
            return Json(result);
        }
    }
}