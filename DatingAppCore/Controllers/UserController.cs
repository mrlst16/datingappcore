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
        [Authorization]
        public async Task<JsonResult> LoginOrSignup(LoginOrSignupRequest request)
        {
            var service = IOCRegistry.Container.GetInstance<ILoginOrSignupService>();
            var result = service.LoginOrSignup(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> GetUser(GetUserRequest request)
        {
            IGetUserService service = IOCRegistry.Container.GetInstance<IGetUserService>();
            var result = service.GetUser(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> SetUserSettings(SetPropertiesRequest request)
        {
            ISetPropertiesService service = IOCRegistry.Container.GetInstance<ISetPropertiesService>();
            var result = service.Set(request);
            return Json(result);
        }

        [Authorization]
        public async Task<JsonResult> SetPhotos(SetPhotosRequest request)
        {
            ISetPhotosService service = IOCRegistry.Container.GetInstance<ISetPhotosService>();
            var result = service.Set(request);
            return Json(result);
        }
    }
}