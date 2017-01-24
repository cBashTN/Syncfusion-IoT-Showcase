using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace VisualisationDemo
{
    public static class TelemetryData
    {
        private const string DataFilePath = @"DemoMeasurement.csv";

        public static ObservableCollection<Measurement> GetMeasurements()
        {
            ObservableCollection<Measurement> measurements;
            
            using (var sr = new StreamReader(DataFilePath))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.Delimiter = ";";
                reader.Configuration.HasHeaderRecord = true;
                reader.Configuration.RegisterClassMap<MeasurementsMap>();
                IEnumerable<Measurement> records = reader.GetRecords<Measurement>();
                measurements = new ObservableCollection<Measurement>(records);
            }
            return measurements;
        }
    }


    public class Measurement
    {
        public DateTime Timestamp { get; set; }
        public string DeviceId { get; set; }
        public double BatteryVoltage { get; set; }
        public double P1 { get; set; }  //Pressure 1
        public double Tob1 { get; set; }  //Temperature 1 on board
    }

    public class MeasurementsMap : CsvClassMap<Measurement>
    {
        public MeasurementsMap()
        {
            Map(m => m.Timestamp).TypeConverterOption(DateTimeStyles.AdjustToUniversal);
            Map(m => m.DeviceId);
            Map(m => m.BatteryVoltage);
            Map(m => m.P1);
            Map(m => m.Tob1);
        }
    }

}
