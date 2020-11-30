//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace DatingAppCore.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LocationController : Controller
//    {

//        [HttpPost("record_user_location")]
//        public async Task<IActionResult> RecordUserLocation(UserLocation request)
//        {
//            var result = await _recordUserLocationService.Record(request);
//            return Json(result);
//        }
//    }
//}
