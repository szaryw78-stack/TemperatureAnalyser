using System;

namespace TemperatureAnalyser.DataCollector
{
    public class GasData : TemperaturesData
    {
        public int Id { get; set; }
        public DateTime CollectionDatetime { get; set; }
        public double Value { get; set; }
        public int Fireplace { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public double Usage { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double Zone1 { get; set; }
        public double Zone2 { get; set; }
        public int automatic { get; set; }
        public string memoNote { get; set; }

    }
}
