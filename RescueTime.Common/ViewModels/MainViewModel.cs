using System.Threading.Tasks;
using MassivePixel.RescueTime.Common.Data;

namespace MassivePixel.RescueTime.Common.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public bool IsWorking
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool IsLoaded
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Summary Summary
        {
            get { return Get<Summary>(); }
            set { Set(value); }
        }

        public async Task LoadDataAsync()
        {
            if (IsWorking)
                return;
            IsWorking = true;

            try
            {
                Summary = await FetchService.GetSummaryAsync();
                IsLoaded = true;
            }
            finally
            {
                IsWorking = false;
            }
        }
    }
}
