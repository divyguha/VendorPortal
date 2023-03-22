using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using VendorApi.Controllers;
using Xunit;
namespace VendorApi.Test.Unit.UnitTest
{
    [TestClass]
    public class POControllerTest
    {

        private readonly POController _controller;
        HttpRequestMessage request;
        HttpResponseMessage response;

        public POControllerTest(POController _controllerTest)
        {
            _controller = _controllerTest;
        }
        [TestMethod()]
        public void GetPOTest()
        {
            var data = _controller.GetAll();
            Xunit.Assert.NotNull(data);
        }
    }
}
