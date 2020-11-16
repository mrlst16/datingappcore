using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using CommonCore.IOC;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Messages;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : Controller
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly ILookupConversationService _readMessageService;
        
		public MessagingController(
            ISendMessageService sendMessageService,
            ILookupConversationService readMessageService
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
        public async Task<IActionResult> Read(GetConversationRequest request)
        {
            var result = await _readMessageService.Lookup(request);
            return Json(result);
        }
    }
}