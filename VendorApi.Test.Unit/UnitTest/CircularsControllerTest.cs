using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using VendorApi.Controllers;

namespace VendorApi.Test.Unit.UnitTest
{
    [TestClass]
    public class CircularsControllerTest
    {
        private readonly CircularsController _controller;
        HttpRequestMessage request;
        HttpResponseMessage response;

        public CircularsControllerTest(CircularsController _controllerTest)
        {
            _controller = _controllerTest;
        }
        

        [TestMethod]
        public void GetCircularTest()
        {
            var data = _controller.GetAll();
            Assert.IsNotNull(data);
        }

    }
}
