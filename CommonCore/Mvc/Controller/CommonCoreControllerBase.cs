using CommonCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DatingApp.API.Services.Interfaces;
using Newtonsoft.Json;

namespace CommonCore.Mvc.Controller
{
    public abstract class CommonCoreControllerBase : ControllerBase
    {
        protected IContainer Container { get; set; }
        public CommonCoreControllerBase(IContainer container)
        {
            this.Container = container;
        }

        protected async Task<IActionResult> CallWithAuthAsync(Func<IActionResult> action)
        {
            var auth = Request.Headers["Authorization"];
            if (auth.None()) return Unauthorized();
            var service = Container.Resolve<IAuthorizationService>();

            bool authorized = service.Authorize(Request.Headers);
            if (!authorized) return Unauthorized();
            return action();
        }

        protected IActionResult Json(object obj)
        {
            return Ok(JsonConvert.SerializeObject(obj));
        }
    }
}
