using DatingAppCore.BLL.Signup.Requests;
using StructureMap;
using System.Web;
using System.Web.Mvc;
using DatingAppCore.BLL.Services.Interfaces;
using System.Threading.Tasks;
using DatingAppCore.API.Security;
using DatingAppCore.BLL.Requests;

namespace DatingAppCore.API.Controllers
{
    public class UserController : ControllerBase
    {

        ILoginOrSignupService loginOrSignupService;
        IGetUserService getUserService;
        ISetPropertiesService setPropertiesService;
        ISetPhotosService setPhotosService;

        [AuthorizationAttribute]
        public async Task<JsonResult> LoginOrSignup(LoginOrSignupRequest request)
        {
            loginOrSignupService = HttpContext.RequestServices.GetService<ILoginOrSignupService>();
            var result = loginOrSignupService.LoginOrSignup(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> GetUser(GetUserRequest request)
        {
            getUserService = HttpContext.RequestServices.GetService<IGetUserService>();
            var result = getUserService.GetUser(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> SetUserSettings(SetPropertiesRequest request)
        {
            setPropertiesService = HttpContext.RequestServices.GetService<ISetPropertiesService>();
            var result = setPropertiesService.Set(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> SetPhotos(SetPhotosRequest request)
        {
            setPhotosService = HttpContext.RequestServices.GetService<ISetPhotosService>();
            var result = setPhotosService.Set(request);
            return Json(result);
        }
    }
}