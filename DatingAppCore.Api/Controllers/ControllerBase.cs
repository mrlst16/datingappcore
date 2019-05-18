using CommonCore.IOC;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Controllers
{
    public class ControllerBase : Controller
    {
        protected IServiceProvider ServiceProvider { get; set; } = KeyedDependencyResolver.Instance.Default;
    }
}
