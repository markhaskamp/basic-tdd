using System;

namespace tdd_demo.Services
{
    public class TimeSvc : ITimeSvc
    {
        public DateTime GetCurrentTime() {
            return DateTime.Now;
        }
    }
}