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
        private ISwipeService swipeService;

        [Authorization]
        public async Task<JsonResult> PotentialMatches(FindMatchRequest request)
        {
            var service = IOCRegistry.Container.GetInstance<IPotentialMatchesService>();
            var result = service.FindPotentialMatches(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> Swipe(SwipeDTO request)
        {
            var service = IOCRegistry.Container.GetInstance<ISwipeService>();
            var result = service.Swipe(request);
            return Json(result);
        }
    }
}