using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            var mostProductive = _vm.Summary.Times.FirstOrDefault(i => i.Key == 2);
            var productive = _vm.Summary.Times.FirstOrDefault(i => i.Key == 1);
            var neutral = _vm.Summary.Times.FirstOrDefault(i => i.Key == 0);
            var distracting = _vm.Summary.Times.FirstOrDefault(i => i.Key == -1);
            var veryDistracting = _vm.Summary.Times.FirstOrDefault(i => i.Key == -2);

            double total = _vm.Summary.Total;

            double offset = 0;

            double length = mostProductive.Value;
            PieChart.Children.Add(CreatePath(Color.FromArgb(255, 47, 120, 189), offset, length, total));

            offset += length;
            length = productive.Value;
            PieChart.Children.Add(CreatePath(Color.FromArgb(255, 57, 91, 150), offset, length, total));

            offset += length;
            length = neutral.Value;
            PieChart.Children.Add(CreatePath(Color.FromArgb(255, 101, 85, 104), offset, length, total));

            offset += length;
            length = distracting.Value;
            PieChart.Children.Add(CreatePath(Color.FromArgb(255, 146, 52, 59), offset, length, total));

            offset += length;
            length = veryDistracting.Value;
            PieChart.Children.Add(CreatePath(Color.FromArgb(255, 197, 57, 47), offset, length, total));
        }
        
        private static Path CreatePath( Color color, double offset, double length, double total)
        {
            const double size = (480 - 48) / 2;

            var angle1 = offset / total * 360 * Math.PI / 180;
            var angle2 = (offset + length) / total * 360 * Math.PI / 180;

            var origin = new Point(size + Math.Sin(angle1) * size, size - Math.Cos(angle1) * size);
            var destination = new Point(size + Math.Sin(angle2) * size, size - Math.Cos(angle2) * size);

            var figure = new PathFigure
            {
                StartPoint = origin
            };
            figure.Segments.Add(new ArcSegment
            {
                Point = destination,
                Size = new Size(size,size),
                IsLargeArc = length / total * 360 > 180,
                SweepDirection = SweepDirection.Clockwise
            });
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);
            return new Path
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = 25,
                Data = geometry
            };
        }
    }
}