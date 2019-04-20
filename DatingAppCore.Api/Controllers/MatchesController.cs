using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.Api.Security;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Matching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        [Authorization]
        public async Task<string> PotentialMatches(FindMatchRequest request)
        {
            var service = Program.Container.Resolve<IPotentialMatchesService>();
            var result = service.FindPotentialMatches(request);
            return JsonConvert.SerializeObject(result);
        }

        [Authorization]
        public async Task<string> Swipe(SwipeDTO request)
        {
            var service = Program.Container.Resolve<ISwipeService>();
            var result = service.Swipe(request);
            return JsonConvert.SerializeObject(result);
        }
    }
}