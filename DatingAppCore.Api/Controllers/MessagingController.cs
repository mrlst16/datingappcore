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
using Microsoft.AspNetCore.Authorization;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : CommonCoreControllerBase
    {
        public MessagingController() : base(Program.Container)
        {

        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(MessageDTO request)
        {
            var service = Program.Container.Resolve<ISendMessageService>();
            var result = await service.Send(request);
            return Json(result);
        }
    }
}