using DatingAppCore.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Tests.Tests
{
    [TestClass]
    public abstract class TestClassBase
    {
        [TestInitialize]
        public void Setup() => 
            new TestSetup()
            .SetupIOC();
    }
}
