using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.DTO.Reviewing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using DatingAppCore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : CommonCore.Mvc.Controller.CommonCoreControllerBase
    {
        public ReviewsController() : base()
        {
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(ReviewDTO request)
        {
            var service = ServiceProvider.GetService<ISendReviewService>();
            var result = await service.Send(request);
            return Ok(result);
        }
    }
}