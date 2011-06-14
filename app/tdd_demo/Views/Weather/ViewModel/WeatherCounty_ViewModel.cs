
namespace tdd_demo.Views.Weather.ViewModel
{
    public class WeatherCounty_ViewModel
    {
        public bool SecondsAreOdd;
        public string Description { get; set; }

        private int _seconds;
        public int Seconds {
            get { return _seconds; } 
            set {
                _seconds = value;
                SecondsAreOdd = ((value%2) == 1);
            }
        }
    }
}