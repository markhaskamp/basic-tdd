using System;
using System.Web.Mvc;
using tdd_demo.Services;
using tdd_demo.Views.Weather.ViewModel;

namespace tdd_demo.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherSvc weatherSvc;
        private ITimeSvc timeSvc;

        public WeatherController(IWeatherSvc weatherSvc, ITimeSvc timeSvc) {
            this.weatherSvc = weatherSvc;
            this.timeSvc = timeSvc;
        }

        public ViewResult County(string id) {
            WeatherCounty_ViewModel viewModel = new WeatherCounty_ViewModel();
            var weather = weatherSvc.GetWeatherForCounty(id);
            DateTime currentTime = timeSvc.GetCurrentTime();

            viewModel.Description = weather;
            viewModel.Seconds = currentTime.Second;

            return View();
//            return Json(viewModel, "text/html", JsonRequestBehavior.AllowGet);
        }

        public JsonResult CountyJSON(string id) {
            WeatherCounty_ViewModel viewModel = new WeatherCounty_ViewModel();
            var weather = weatherSvc.GetWeatherForCounty(id);
            DateTime currentTime = timeSvc.GetCurrentTime();

            viewModel.Description = weather;
            viewModel.Seconds = currentTime.Second;

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
