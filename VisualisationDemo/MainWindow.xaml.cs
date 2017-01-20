using System.Linq;
using System.Windows;


namespace VisualisationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TelemetryDataViewModel _vm;
        private readonly double _vmP1YAxisMaximum;
        private readonly double _vmP1YAxisMinimum;
        public MainWindow()
        {
            InitializeComponent();

            _vm = (TelemetryDataViewModel)this.DataContext;

            _vm.PrimaryAxisMaximum = _vm.MeasurementsOfDeviceA.Max(i => i.Timestamp);
            _vm.PrimaryAxisMinimum = _vm.MeasurementsOfDeviceA.Min(i => i.Timestamp);

            _vm.PrimaryAxisViewRangeStart = _vm.PrimaryAxisMinimum;
            _vm.PrimaryAxisViewRangeEnd   = _vm.PrimaryAxisMaximum;

            _vmP1YAxisMaximum = _vm.MeasurementsOfDeviceA.Max(i => i.P1);
            _vmP1YAxisMinimum = _vm.MeasurementsOfDeviceA.Min(i => i.P1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            _vm.P1YAxisMaximum = _vmP1YAxisMaximum;
            _vm.P1YAxisMinimum = _vmP1YAxisMinimum;
        }
    }
}
