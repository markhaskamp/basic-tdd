using System.Web.Mvc;
using tdd_demo.Services;

namespace tdd_demo.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherSvc weatherSvc;

        public WeatherController(IWeatherSvc weatherSvc) {
            this.weatherSvc = weatherSvc;
        }

        public JsonResult County(string countyName) {
            var weather = weatherSvc.GetWeatherForCounty(countyName);

            return Json(weather, "text/html", JsonRequestBehavior.AllowGet);
        }

    }
}
