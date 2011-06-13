using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tdd_demo.Controllers;

namespace tdd_demo_test
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void County_method_returns_json() {
            WeatherController controller = new WeatherController();
            ActionResult actionResult = controller.County("Montgomery");

            Assert.AreEqual(typeof (JsonResult), actionResult.GetType());
        }
    }
}
