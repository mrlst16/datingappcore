using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.DTO.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using DatingAppCore.BLL.Services.Interfaces;
using CommonCore.Mvc.Controller;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : CommonCoreControllerBase
    {
        public MessagingController() : base(Program.Container)
        {

        }

        public async Task<IActionResult> Send(MessageDTO request)
        {
            return await CallWithAuthAsync(() =>
            {
                var service = Program.Container.Resolve<ISendMessageService>();
                var result = service.Send(request);
                return Json(result);
            });
        }
    }
}