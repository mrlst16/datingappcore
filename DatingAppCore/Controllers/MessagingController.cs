using DatingAppCore.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Messages;

namespace DatingAppCore.API.Controllers
{
    public class MessagingController : ControllerBase
    {
        [Authorization]
        public async Task<JsonResult> Send(MessageDTO request)
        {
            var service = IOCRegistry.Container.GetInstance<ISendMessageService>();
            var result = service.Send(request);
            return Json(result);
        }
    }
}