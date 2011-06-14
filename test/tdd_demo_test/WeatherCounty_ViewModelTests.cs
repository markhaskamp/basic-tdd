using Microsoft.VisualStudio.TestTools.UnitTesting;
using tdd_demo.Views.Weather.ViewModel;

namespace tdd_demo_test
{
    [TestClass]
    public class WeatherCounty_ViewModelTests
    {

        [TestMethod]
        public void when_seconds_are_even_then_SecondsAreOdd_flag_is_false() {
            WeatherCounty_ViewModel viewModel = new WeatherCounty_ViewModel();

            viewModel.Description = "eddie would go";
            viewModel.Seconds = 42;

            Assert.IsFalse(viewModel.SecondsAreOdd);
        }

        [TestMethod]
        public void when_seconds_are_odd_then_SecondsAreOdd_flag_is_true() {
            WeatherCounty_ViewModel viewModel = new WeatherCounty_ViewModel();

            viewModel.Description = "eddie would go";
            viewModel.Seconds = 41;

            Assert.IsTrue(viewModel.SecondsAreOdd);
        }
    }
}