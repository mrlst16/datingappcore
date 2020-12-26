using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DatingAppCore.Dto.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Dto.Members;
using DatingAppCore.Entities.Matching;
using DatingAppCore.BLL.Interfaces.Services;
using DatingAppCore.Api.Extensions;
using FluentValidation;
using CommonCore.Models.Responses;
using CommonCore.Api.Extensions;

namespace DatingAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {

        private readonly IMatchesService _matchesService;
        private readonly IValidator<Swipe> _swipeValidator;

        public MatchesController(
            IMatchesService matchesService,
            IValidator<Swipe> swipeValidator
            )
        {
            _matchesService = matchesService;
            _swipeValidator = swipeValidator;
        }

        [HttpPost("potential_matches")]
        public async Task<IActionResult> PotentialMatches(FindMatchesRequest request)
        {
            var result = await _matchesService.FindPotentialMatches(request);
            return Json(result);
        }


        [HttpPost("swipe")]
        public async Task<IActionResult> Swipe(Swipe request)
        {
            var validationResult = _swipeValidator.Validate(request);
            if (!validationResult.IsValid) return StatusCode(400, validationResult.To400<bool>());

            await _matchesService.Swipe(request);
            return this.Return200Or500(new ApiResponse<bool>()
            {
                Data = true,
                SuccessMessage = "Successfully saved swipe",
                Sucess = true
            });
        }

        //[Authorize(AuthenticationSchemes = "Basic")]
        //[HttpPost("matches")]
        //public async Task<IActionResult> Matches(LookupByUserIDRequest request)
        //{
        //    var result = await _getMatchesService.GetMatches(request);
        //    return Json(result);
        //}

        //[Authorize(AuthenticationSchemes = "Basic")]
        //[HttpPost("is_match")]
        //public async Task<IActionResult> IsMatch(IsMatchRequest request)
        //{
        //    var result = await _getMatchesService.IsMatch(request.User1ID, request.User2ID);
        //    return Json(result);
        //}
    }
}