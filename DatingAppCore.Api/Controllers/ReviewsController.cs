using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.Api.Security;
using DatingAppCore.DTO.Reviewing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        [Authorization]
        public async Task<string> Send(ReviewDTO request)
        {
            var service = Program.Container.Resolve<ISendReviewService>();
            var result = service.Send(request);
            return JsonConvert.SerializeObject(result);
        }
    }
}