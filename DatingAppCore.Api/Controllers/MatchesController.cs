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
using CommonCore.Mvc.Controller;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : CommonCoreControllerBase
    {
        public MatchesController() : base(Program.Container)
        {

        }

        public async Task<IActionResult> PotentialMatches(FindMatchRequest request)
        {
            return await CallWithAuthAsync(() =>
            {
                var service = Program.Container.Resolve<IPotentialMatchesService>();
                var result = service.FindPotentialMatches(request);
                return Json(result);
            });
        }

        public async Task<IActionResult> Swipe(SwipeDTO request)
        {
            return await CallWithAuthAsync(() =>
            {
                var service = Program.Container.Resolve<ISwipeService>();
                var result = service.Swipe(request);
                return Json(result);
            });
        }
    }
}