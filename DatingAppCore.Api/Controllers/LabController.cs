using CommonCore.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Controllers
{
    public class LabRequest
    {
        public string Value { get; set; }
    }

    [Route("api/[controller]")]
    public class LabController : Controller
    {
        private readonly ILogger<LabController> _logger;

        public LabController(
            ILogger<LabController> logger
            )
        {
            _logger = logger;
        }

        [HttpPost("post_echo")]
        public async Task<IActionResult> PostEcho([FromBody]LabRequest request)
        {
            Response<string> response = request.Value;

            return Json(response);
        }

        [HttpGet("get_echo")]
        public async Task<IActionResult> GetEcho([FromQuery]string request)
        {
            _logger.LogInformation(request);
            return Json(request);
        }
    }
}
