using Autofac;
using DatingAppCore.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Test.Tests
{
    [TestClass]
    public abstract class TestClassBase
    {
        public static IContainer Container { get; set; }

        [TestInitialize]
        public void Setup() => 
            new TestSetup()
            .SetupIOC();
    }
}
