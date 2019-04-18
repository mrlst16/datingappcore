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
        [Authorization]
        public async Task<JsonResult> Send(ReviewDTO request)
        {
            var service = IOCRegistry.Container.GetInstance<ISendReviewService>();
            var result = service.Send(request);
            return Json(result);
        }
    }
}