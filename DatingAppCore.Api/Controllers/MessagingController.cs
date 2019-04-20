using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppCore.Api.Security;
using DatingAppCore.DTO.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Autofac;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        [Authorization]
        public async Task<string> Send(MessageDTO request)
        {
            var service = Program.Container.Resolve<ISendMessageService>();
            var result = service.Send(request);
            return JsonConvert.SerializeObject(result);
        }
    }
}