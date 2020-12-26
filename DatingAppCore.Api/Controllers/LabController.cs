using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CommonCore.Models.Responses;
using CommonCore.Interfaces.Repository;
using DatingAppCore.Entities.Members;

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
        private readonly ICrudRepositoryFactory _crudRepository;
        public LabController(
            ILogger<LabController> logger,
            ICrudRepositoryFactory crudRepository
            )
        {
            _logger = logger;
            _crudRepository = crudRepository;
        }

        [HttpPost("post_echo")]
        public async Task<IActionResult> PostEcho([FromBody] LabRequest request)
        {
            ApiResponse<string> response = new ApiResponse<string>()
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
