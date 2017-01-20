
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PropertyChanged;

namespace VisualisationDemo
{
    [ImplementPropertyChanged]
    public class TelemetryDataViewModel
    {

        public TelemetryDataViewModel()
        {
            IsP1Enabled = true;
            IsTob1Enabled = true;

           // P1YAxisMaximum = MeasurementsOfDeviceA.Max(i => i.P1);
           // P1YAxisMinimum = MeasurementsOfDeviceA.Min(i => i.P1);
        }


        public bool IsP1Enabled { get; set; }
        public bool IsTob1Enabled { get; set; }

        public double P1YAxisMaximum { get; set; }
        public double P1YAxisMinimum { get; set; }

        public DateTime PrimaryAxisViewRangeStart { get; set; }
        public DateTime PrimaryAxisViewRangeEnd { get; set; }

        public DateTime PrimaryAxisMaximum { get; set; }
        public DateTime PrimaryAxisMinimum { get; set; }

        private static IEnumerable<Measurement> _measurements;
        private static IEnumerable<Measurement> Measurements => _measurements ?? (_measurements = TelemetryData.GetMeasurements());

        private static List<string> _devices;
        public static List<string> Devices => _devices ?? (_devices = Measurements.Select(x => x.DeviceId).Distinct().ToList());

        private static ObservableCollection<Measurement> _measurementsOfDeviceA;
        public ObservableCollection<Measurement> MeasurementsOfDeviceA => _measurementsOfDeviceA ?? (_measurementsOfDeviceA = new ObservableCollection<Measurement>(Measurements.Where(x => x.DeviceId == Devices[0])));

        //private static ObservableCollection<Measurement> _measurementsOfDeviceB;
        //public static ObservableCollection<Measurement> MeasurementsOfDeviceB => _measurementsOfDeviceB ?? (_measurementsOfDeviceB = new ObservableCollection<Measurement>(Measurements.Where(x => x.DeviceId == Devices[1])));

        //private static ObservableCollection<Measurement> _measurementsOfDeviceC;
        //public static ObservableCollection<Measurement> MeasurementsOfDeviceC
        //{
        //    get
        //    {
        //        if (_measurementsOfDeviceC != null) return _measurementsOfDeviceC;
        //        List<Measurement> artificiallyOldMeasurements = Measurements.Where(x => x.DeviceId == Devices[2]).ToList();
        //        artificiallyOldMeasurements.ForEach(m => m.Timestamp = m.Timestamp - (TimeSpan.FromDays(3)));
        //        _measurementsOfDeviceC = new ObservableCollection<Measurement>(artificiallyOldMeasurements);
        //        return _measurementsOfDeviceC;
        //    }
        //}

        //private static ObservableCollection<Measurement> _measurementsOfDeviceD;
        //public static ObservableCollection<Measurement> MeasurementsOfDeviceD => _measurementsOfDeviceD ?? (_measurementsOfDeviceD = new ObservableCollection<Measurement>(Measurements.Where(x => x.DeviceId == Devices[3])));


    }
}