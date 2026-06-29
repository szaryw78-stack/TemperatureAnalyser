using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureAnalyser.DataCollector
{
    public class GasDataImprooved
    {
        public int id { get; set; }
        public double realcounter { get; set; }
        public double virtualcounter { get; set; }
        public DateTime createdDatetime { get; set; }
        public double difference { get; set; }
    }
}
