using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tdd_demo.Controllers;
using tdd_demo.Services;
using Telerik.JustMock;

namespace tdd_demo_test
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void County_method_returns_json() {
            IWeatherSvc weatherSvc = Mock.Create<IWeatherSvc>();
            WeatherController weatherController = new WeatherController(weatherSvc);

            ActionResult actionResult = weatherController.County("Montgomery");

            Assert.AreEqual(typeof (JsonResult), actionResult.GetType());
        }

        [TestMethod]
        public void County_method_calls_WeatherSvc_GetWeatherForCounty() {
            IWeatherSvc weatherSvc = Mock.Create<IWeatherSvc>();
            WeatherController weatherController = new WeatherController(weatherSvc);

            Mock.Arrange(() => weatherSvc.GetWeatherForCounty("Montgomery"))
                                .IgnoreArguments()
                                .MustBeCalled();

            weatherController.County("Montgomery");  // act

            Mock.Assert(weatherSvc); // assert
        }
    }
}
