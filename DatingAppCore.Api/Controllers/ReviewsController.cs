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

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : CommonCore.Mvc.Controller.CommonCoreControllerBase
    {
        public ReviewsController() : base(Program.Container)
        {
        }

        public async Task<IActionResult> Send(ReviewDTO request)
        {
            return await CallWithAuthAsync(()=> {
                var service = Program.Container.Resolve<ISendReviewService>();
                var result = service.Send(request);
                return Ok(result);
            });
        }
    }
}