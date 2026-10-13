using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TemperatureAnalyser
{
    public class RestInterfaceTemperatures
    {
        private static string token = "NjljMjNmZDY3MzdiMDEzODY2ZmZhY2M3NmY1NmVhMmQ4MTEzYjU4YjBlZjVhMmNjMjNmZTE5MDU1N2M4MmE1Yg.aHR0cHM6Ly9zdnI2Mi5zdXBsYS5vcmc=";
        private static string url = "https://svr62.supla.org/api/v2.3.0/channels/4098/measurement-logs";
        private static readonly HttpClient Client = new HttpClient();
        private readonly HttpClient client;

        public RestInterfaceTemperatures() : this(Client)
        {
        }

        internal RestInterfaceTemperatures(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<DataCollector.TemperaturesData>> GetTemperaturesFromSuplaAsync(
            CancellationToken cancellationToken)
        {
            var result = new List<DataCollector.TemperaturesData>();
            var temperatures = new List<Temperatures>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    Newtonsoft.Json.JsonConvert.PopulateObject(data, temperatures);
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
                    foreach (var item in temperatures)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        DateTime sourceDate = epoch.AddSeconds(item.date_timestamp);
                        int timeOffset = sourceDate.IsDaylightSavingTime() ? 2 : 1;
                        DateTime localDate = sourceDate.ToLocalTime();
                        DateTime measurementDate = sourceDate.AddHours(timeOffset).ToLocalTime();
                        result.Add(new DataCollector.TemperaturesData
                        {
                            TimeStamp = item.date_timestamp,
                            DateAndTime = measurementDate,
                            Temperature = item.temperature,
                            Date = localDate.Date,
                            TimeSpan = new TimeSpan(measurementDate.Hour, localDate.Minute, localDate.Second)
                        });
                    }
                }
            }
            return result;
        }
        public class Temperatures
        {
            public double date_timestamp { get; set; }
            public DateTime DateTime { get; set; }
            public double temperature { get; set; }
        }
    }
}
