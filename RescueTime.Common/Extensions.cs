using System;
using GalaSoft.MvvmLight.Ioc;
using MassivePixel.RescueTime.Common.Platform;

namespace MassivePixel.RescueTime.Common
{
    public static class Extensions
    {
        public static void Report(this Exception ex)
        {
            if (ex == null)
                return;

            try
            {
                SimpleIoc.Default.GetInstance<IAnalytics>().ReportError(ex.ToString());
            }
            catch { }
        }
    }
}
