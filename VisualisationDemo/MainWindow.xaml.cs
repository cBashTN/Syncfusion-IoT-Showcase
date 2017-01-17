using System.Linq;
using System.Windows;


namespace VisualisationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (TelemetryDataViewModel)this.DataContext;
            vm.P1YAxisMaximum = vm.MeasurementsOfDeviceA.Max(i => i.P1);
            vm.P1YAxisMinimum = vm.MeasurementsOfDeviceA.Min(i => i.P1);
        }
    }
}
