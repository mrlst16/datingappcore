using CommonCore.Responses;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("post_echo")]
        public async Task<IActionResult> PostEcho([FromBody]LabRequest request)
        {
            Response<string> response = request.Value;

            return Json(response);
        }

        [HttpGet("get_echo")]
        public async Task<IActionResult> GetEcho([FromQuery]string request)
        {
            return Json(request);
        }
    }
}
