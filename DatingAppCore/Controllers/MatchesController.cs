using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DatingAppCore.API.Security;
using DatingAppCore.BLL.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCore.API.Controllers
{
    public class MatchesController : ControllerBase
    {
        private IPotentialMatchesService potentialMatchesService;
        private ISwipeService swipeService;

        public MatchesController(IPotentialMatchesService potentialMatchesService, ISwipeService swipeService)
        {
            this.potentialMatchesService = potentialMatchesService;
            this.swipeService = swipeService;
        }

        [Authorization]
        public async Task<JsonResult> PotentialMatches(FindMatchRequest request)
        {
            potentialMatchesService = HttpContext.RequestServices.GetService<IPotentialMatchesService>();
            var result = potentialMatchesService.FindPotentialMatches(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> Swipe(SwipeDTO request)
        {
            swipeService = HttpContext.RequestServices.GetService<ISwipeService>();
            var result = swipeService.Swipe(request);
            return Json(result);
        }
    }
}