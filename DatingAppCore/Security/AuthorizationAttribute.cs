using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DatingAppCore.API.Services.Interfaces;
using DatingAppCore.API.Services.Requests;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DatingAppCore.API.Security
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DatingAppCore.API.Controllers.ControllerBase controller
                = (DatingAppCore.API.Controllers.ControllerBase)filterContext.Controller;

            try
            {
                IAuthorizationService service = IOCRegistry.Container.GetInstance<IAuthorizationService>();
                if (!service.Authorize(new AuthorizationRequest()
                {
                    ClientID = Guid.Parse((string)filterContext.ActionArguments["client_id"]),
                    Data = (string)filterContext.ActionArguments["Authorization"]
                }))
                {
                    throw new HttpException("Failed to Authoirze Request", 401);
                }
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message, 401);
            }
        }
    }
}