using System.Collections.Generic;

namespace tdd_demo.Views.Weather.ViewModel
{
    public class WeatherIndex_ViewModel
    {
        public IList<string> Counties { get; set; }

        public WeatherIndex_ViewModel() {
            Counties = new List<string>();
        }
    }
}