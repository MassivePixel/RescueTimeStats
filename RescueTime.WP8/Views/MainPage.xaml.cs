using System.Windows.Navigation;
using MassivePixel.RescueTime.Common.ViewModels;

namespace MassivePixel.RescueTime.WP8.Views
{
    public partial class MainPage
    {
        private readonly MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
            DataContext = _vm = new MainViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!_vm.IsLoaded)
                await _vm.LoadDataAsync();
        }
    }
}