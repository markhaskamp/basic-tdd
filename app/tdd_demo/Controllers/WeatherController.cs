using System.Web.Mvc;

namespace tdd_demo.Controllers
{
    public class WeatherController : Controller
    {
        public JsonResult County(string countyName)
        {
            return Json("eddie would go", "text/html");
        }

    }
}
