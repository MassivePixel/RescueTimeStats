using MassivePixel.RescueTime.Common.Platform;

namespace MassivePixel.RescueTime.WP8.Platform
{
    public class Analytics : IAnalytics
    {
        public void ReportError(string error)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendException(error, false);
        }
    }
}
