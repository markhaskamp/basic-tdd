using tdd_demo.Castle_IOC;

namespace tdd_demo.Services
{
    public interface IWeatherSvc : IDependency
    {
        string GetWeatherForCounty(string countyName);
    }
}