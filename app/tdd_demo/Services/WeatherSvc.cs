

namespace tdd_demo.Services
{
    public class WeatherSvc : IWeatherSvc
    {
        public string GetWeatherForCounty(string countyName) {
            return("sunny");
        }
    }
}