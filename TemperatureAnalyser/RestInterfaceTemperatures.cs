using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace TemperatureAnalyser
{
    public class RestInterfaceTemperatures
    {
        private static string token = "NjljMjNmZDY3MzdiMDEzODY2ZmZhY2M3NmY1NmVhMmQ4MTEzYjU4YjBlZjVhMmNjMjNmZTE5MDU1N2M4MmE1Yg.aHR0cHM6Ly9zdnI2Mi5zdXBsYS5vcmc=";
        private static string url = "https://svr62.supla.org/api/v2.3.0/channels/4098/measurement-logs";
        public RestInterfaceTemperatures()
        {

        }


        public List<DataCollector.TemperaturesData> GetTemperaturesFromSupla()
        {
            var result = new List<DataCollector.TemperaturesData>();
            var temperatures = new List<Temperatures>();

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //    string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:MM:ss" };

                var response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    Newtonsoft.Json.JsonConvert.PopulateObject(data.ToString(), temperatures);

                    foreach (var item in temperatures)
                    {
                        int timeOffset = 0;

                        double ts = item.date_timestamp;
                        DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(ts).ToLocalTime();

                        bool isSummerTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).IsDaylightSavingTime();
                        if (isSummerTime)  //czas letni
                        {
                            timeOffset = 2;
                        }
                        else  //czas zimowy
                            timeOffset = 1;

                       


                        var temp = new DataCollector.TemperaturesData
                        {
                            TimeStamp = item.date_timestamp,
                            DateAndTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).AddHours(timeOffset).ToLocalTime(),
                            Temperature = item.temperature,
                            Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).ToLocalTime().Date,
                            TimeSpan = new TimeSpan(new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).AddHours(timeOffset).ToLocalTime().Hour,
                                            new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).ToLocalTime().Minute,
                                            new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(item.date_timestamp).ToLocalTime().Second)

                        };
                        result.Add(temp);

                    }

                }


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Wystąpił błąd podczas ustanawiania połączenia REST. Strona www.supla.org nie odpowiada lub nie masz połączenia z internetem. Wyjątek:" + ex.Message, "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);



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
