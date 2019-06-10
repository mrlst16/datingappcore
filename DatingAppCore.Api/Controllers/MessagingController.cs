using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.DTO.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Interfaces;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : Controller
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IReadMessageService _readMessageService;
        
		public MessagingController(
            ISendMessageService sendMessageService,
            IReadMessageService readMessageService
            )
        {
            _sendMessageService = sendMessageService;
            _readMessageService = readMessageService;
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("send")]
        public async Task<IActionResult> Send(MessageDTO request)
        {
            var result = await _sendMessageService.Send(request);
            return Json(result);
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpPost("read")]
        public async Task<IActionResult> Read(LookupByUserIDRequest request)
        {
            var result = await _readMessageService.ReadMessages(request);
            return Json(result);
        }
    }
}