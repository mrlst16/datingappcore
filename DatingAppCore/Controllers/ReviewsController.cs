using DatingAppCore.API.Security;
using DatingAppCore.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Reviewing;

namespace DatingAppCore.API.Controllers
{
    public class ReviewsController : ControllerBase
    {

        ISendReviewService sendReviewService;

        public ReviewsController(ISendReviewService sendReviewService)
        {
            this.sendReviewService = sendReviewService;
        }

        [Authorization]
        public async Task<JsonResult> Send(ReviewDTO request)
        {
            sendReviewService = HttpContext.RequestServices.GetService<ISendReviewService>();
            var result = service.Send(request);
            return Json(result);
        }
    }
}