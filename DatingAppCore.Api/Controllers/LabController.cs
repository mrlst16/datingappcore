using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CommonCore.Models.Responses;

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
        public async Task<IActionResult> PostEcho([FromBody] LabRequest request)
        {
            SimpleResponse<string> response = new SimpleResponse<string>()
            {
                Data = request.Value
            };

            return Json(response);
        }

        [HttpGet("get_echo")]
        public async Task<IActionResult> GetEcho([FromQuery] string request)
        {
            _logger.LogInformation(request);
            return Json(request);
        }
    }
}
