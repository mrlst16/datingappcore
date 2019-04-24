using Autofac;
using DatingApp.API.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Test.Tests
{
    [TestClass]
    public class ServiceTests : TestClassBase
    {
        [TestMethod]
        public void Lab()
        {
            var service = Container.Resolve<IAuthorizationService>();

        }

    }
}
