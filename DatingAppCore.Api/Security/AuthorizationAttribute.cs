using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DatingApp.API.Services.Interfaces;
using DatingApp.API.Services.Requests;
using Microsoft.AspNetCore.Mvc.Filters;
using Autofac;
using DatingAppCore.BLL.Services.Interfaces;

namespace DatingAppCore.Api.Security
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                IAuthorizationService service = Program.Container.Resolve<IAuthorizationService>();
                if (!service.Authorize(new AuthorizationRequest()
                {
                    ClientID = Guid.Parse((string)filterContext.ActionArguments["client_id"]),
                    Data = (string)filterContext.ActionArguments["Authorization"]
                }))
                {
                    //TODO: throw some http exception it's a 401
                    throw new Exception("UnAuthorized");
                }
            }
            catch (Exception e)
            {
                //TODO: throw some http exception it's a 401
                throw new Exception("UnAuthorized");
            }
        }
    }
}