using System;

namespace TemperatureAnalyser.DataCollector
{
    public class Prices
    {
        public int id { get; set; }
        public string key { get; set; }
        public double value { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime createdDatetime { get; set; }
        public string description { get; set; }
    }
}
