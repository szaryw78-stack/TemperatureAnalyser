using System;

namespace TemperatureAnalyser.DataCollector
{
    public class TemperaturesData
    {
        public double TimeStamp { get; set; }
        public DateTime DateAndTime { get; set; }
        public double Temperature { get; set; }
        public double AvarageDailyTemperature { get; set; }
        public double AvarageTemeratureAtDay { get; set; }
        public double AvarageTemperatureAtNight { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Id { get; set; }


    }
}
