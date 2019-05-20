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
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : Controller
    {
        private readonly ISendMessageService _sendMessageService;

        public MessagingController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(MessageDTO request)
        {
            var result = await _sendMessageService.Send(request);
            return Json(result);
        }
    }
}