using System;
using tdd_demo.Castle_IOC;

namespace tdd_demo.Services
{
    public interface ITimeSvc : IDependency
    {
        DateTime GetCurrentTime();
    }
}