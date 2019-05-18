using CommonCore.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Controllers
{
    public class LabController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> LabAction()
        {
            Response<object> response =
                new Response<bool>();

            var D = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var F = Path.Combine(D, "");

            response.Result = new
            {
                D = D,
                F = F,

            };

            return Json("~/Views/Lab.cshtml");
        }
    }
}
