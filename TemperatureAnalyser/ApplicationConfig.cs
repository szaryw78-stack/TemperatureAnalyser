using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TemperatureAnalyser
{
    public class ApplicationConfig
    {
        private const string GasColumns =
            "id,collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note";

        private static readonly string[] TemperatureDateFormats =
        {
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm:ss.FFFFFFF",
            "yyyy-MM-ddTHH:mm:ss.FFFFFFF",
            "dd.MM.yyyy HH:mm:ss"
        };

        private SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = " +
                AppDomain.CurrentDomain.BaseDirectory + @"Data\baza.db");
        }

        public List<DataCollector.TemperaturesData> GetTemperaturesGPT()
        {
            return ReadTemperatures("SELECT id,timestamp,datetime,value " +
                "FROM TemperatureData ORDER BY timestamp DESC");
        }

        public List<DataCollector.TemperaturesData> GetTemperatures()
        {
            return ReadTemperatures("SELECT id,timestamp,datetime,value FROM TemperatureData");
        }

        public List<DataCollector.TemperaturesData> GetTemperatures(DateTime dStart, DateTime dEnd)
        {
            return ReadTemperatures("SELECT id,timestamp,datetime,value FROM TemperatureData " +
                "ORDER BY timestamp DESC", dStart, dEnd);
        }

        private List<DataCollector.TemperaturesData> ReadTemperatures(
            string sql, DateTime? start = null, DateTime? end = null)
        {
            var result = new List<DataCollector.TemperaturesData>();
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = ParseDatabaseDate(reader.GetString(2));
                        if (!IsInDateRange(date, start, end))
                            continue;
                        result.Add(new DataCollector.TemperaturesData
                        {
                            Id = reader.GetInt32(0),
                            TimeStamp = reader.GetDouble(1),
                            DateAndTime = date,
                            Temperature = reader.GetDouble(3),
                            Date = date.Date
                        });
                    }
                }
            }
            return result;
        }

        internal static DateTime ParseDatabaseDate(string value)
        {
            DateTime date;
            if (DateTime.TryParseExact(value, TemperatureDateFormats,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;

            // Older inserts used the Windows date format.
            return DateTime.Parse(value, CultureInfo.CurrentCulture);
        }

        private static bool IsInDateRange(DateTime date, DateTime? start, DateTime? end)
        {
            // Text dates cannot be compared chronologically until storage is normalized.
            return (!start.HasValue || date >= start.Value) &&
                (!end.HasValue || date <= end.Value);
        }

        public void InsertTemperatures(List<DataCollector.TemperaturesData> temperatures)
        {
            if (temperatures == null)
                throw new ArgumentNullException(nameof(temperatures));

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    double maxTimestamp;
                    using (var select = new SQLiteCommand(
                        "SELECT MAX(timestamp) FROM TemperatureData", connection, transaction))
                    {
                        var value = select.ExecuteScalar();
                        maxTimestamp = value == DBNull.Value ? -1 : Convert.ToDouble(value);
                    }

                    using (var command = new SQLiteCommand(
                        "INSERT INTO TemperatureData (timestamp,datetime,value) " +
                        "VALUES(@timestamp,@datetime,@value)", connection, transaction))
                    {
                        var timestamp = command.Parameters.Add("@timestamp", DbType.Double);
                        var date = command.Parameters.Add("@datetime", DbType.String);
                        var value = command.Parameters.Add("@value", DbType.Double);
                        command.Prepare();

                        foreach (var item in temperatures)
                        {
                            if (item.TimeStamp <= maxTimestamp)
                                continue;

                            timestamp.Value = item.TimeStamp;
                            date.Value = item.DateAndTime;
                            value.Value = item.Temperature;
                            command.ExecuteNonQuery();
                        }
                    }
                    // Disposing an uncommitted transaction rolls back the entire batch.
                    transaction.Commit();
                }
            }
        }

        public void InsertGasUsage(List<DataCollector.GasData> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand(
                    "INSERT INTO GasDataCollection " +
                    "(collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note) " +
                    "VALUES(@collectiondatetime,@value,@fireplace,@createddatetime,@zone1,@zone2,@automatic,@note)",
                    connection, transaction))
                {
                    var date = command.Parameters.Add("@collectiondatetime", DbType.String);
                    var value = command.Parameters.Add("@value", DbType.Double);
                    var fireplace = command.Parameters.Add("@fireplace", DbType.Int32);
                    var created = command.Parameters.Add("@createddatetime", DbType.String);
                    var zone1 = command.Parameters.Add("@zone1", DbType.Double);
                    var zone2 = command.Parameters.Add("@zone2", DbType.Double);
                    var automatic = command.Parameters.Add("@automatic", DbType.Int32);
                    var note = command.Parameters.Add("@note", DbType.String);
                    command.Prepare();

                    foreach (var item in data)
                    {
                        date.Value = item.CollectionDatetime.ToString();
                        value.Value = item.Value;
                        fireplace.Value = item.Fireplace;
                        created.Value = DateTime.Now.ToString();
                        zone1.Value = item.Zone1;
                        zone2.Value = item.Zone2;
                        automatic.Value = item.automatic;
                        note.Value = (object)item.memoNote ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void InsertPrices(List<DataCollector.Prices> prices, DateTime dt)
        {
            if (prices == null)
                throw new ArgumentNullException(nameof(prices));

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand(
                    "INSERT INTO Prices (key,value,month,year,createdDatetime) " +
                    "VALUES(@key,@value,@month,@year,@createdDatetime)", connection, transaction))
                {
                    var key = command.Parameters.Add("@key", DbType.String);
                    var value = command.Parameters.Add("@value", DbType.Double);
                    command.Parameters.Add("@month", DbType.Int32).Value = dt.Month;
                    command.Parameters.Add("@year", DbType.Int32).Value = dt.Year;
                    var created = command.Parameters.Add("@createdDatetime", DbType.String);
                    command.Prepare();
                    foreach (var item in prices)
                    {
                        key.Value = item.key;
                        value.Value = item.value;
                        created.Value = DateTime.Now;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public List<DataCollector.GasData> GetGasUsageFromFile(string path)
        {
            var result = new List<DataCollector.GasData>();
            foreach (var line in File.ReadLines(path, System.Text.Encoding.Default).Skip(1))
            {
                var fields = line.Split(';');
                result.Add(new DataCollector.GasData
                {
                    CollectionDatetime = Convert.ToDateTime(fields[0]),
                    Value = Convert.ToDouble(fields[1]),
                    Fireplace = Convert.ToInt32(fields[2])
                });
            }
            return result;
        }

        public List<DataCollector.TemperaturesData> GetTemperatureFile(string path)
        {
            var result = new List<DataCollector.TemperaturesData>();
            foreach (var line in File.ReadLines(path, System.Text.Encoding.Default).Skip(1))
            {
                var fields = line.Split(',');
                DateTime date = Convert.ToDateTime(fields[1].Replace('"', ' '));
                result.Add(new DataCollector.TemperaturesData
                {
                    TimeStamp = Convert.ToInt64(fields[0]),
                    DateAndTime = date,
                    Temperature = Convert.ToDouble(fields[2].Replace('.', ',')),
                    Date = date.Date,
                    TimeSpan = date.TimeOfDay
                });
            }
            return result;
        }

        public List<DataCollector.TemperaturesData> AvarageTemperatures(List<DataCollector.TemperaturesData> data)
        {
            return data.GroupBy(item => item.Date.Date)
                .Select(group => new DataCollector.TemperaturesData
                {
                    Date = group.Key,
                    AvarageDailyTemperature = group.Average(item => item.Temperature)
                })
                .OrderBy(item => item.Date)
                .ToList();
        }

        public List<DataCollector.GasData> GetGasUsage()
        {
            return ReadGasUsage("SELECT " + GasColumns +
                " FROM GasDataCollection ORDER BY collectiondatetime");
        }

        public List<DataCollector.GasData> GetGasUsageBevorConterExchange()
        {
            return ReadGasUsage("SELECT " + GasColumns +
                " FROM GasDataCollectionOld ORDER BY collectiondatetime");
        }

        public List<DataCollector.GasData> GetGasUsage(DateTime dStart, DateTime dEnd)
        {
            return ReadGasUsage("SELECT " + GasColumns + " FROM GasDataCollection " +
                "ORDER BY collectiondatetime", dStart, dEnd);
        }

        private List<DataCollector.GasData> ReadGasUsage(
            string sql, DateTime? start = null, DateTime? end = null)
        {
            var result = new List<DataCollector.GasData>();
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = ParseDatabaseDate(reader.GetString(1));
                        if (!IsInDateRange(date, start, end))
                            continue;
                        result.Add(new DataCollector.GasData
                        {
                            Id = reader.GetInt32(0),
                            CollectionDatetime = date,
                            Value = reader.GetDouble(2),
                            Fireplace = reader.GetInt32(3),
                            CreatedDatetime = ParseDatabaseDate(reader.GetString(4)),
                            Month = date.Month,
                            Year = date.Year,
                            Zone1 = reader.IsDBNull(5) ? 0 : reader.GetDouble(5),
                            Zone2 = reader.IsDBNull(6) ? 0 : reader.GetDouble(6),
                            automatic = reader.GetInt32(7),
                            memoNote = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
                        });
                    }
                }
            }
            result = result.OrderBy(item => item.CollectionDatetime).ToList();
            for (int i = 0; i < result.Count - 1; i++)
                result[i].Usage = Math.Round(result[i + 1].Value - result[i].Value, 1);
            return result;
        }

        public DataCollector.GasData GetTemperatureSettings()
        {
            var result = new DataCollector.GasData();
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "SELECT zone1,zone2 FROM GasDataCollection ORDER BY Id DESC LIMIT 1", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Zone1 = reader.GetDouble(0);
                        result.Zone2 = reader.GetDouble(1);
                    }
                }
            }
            return result;
        }

        public void UpdateGasUsage(DataCollector.GasData data)
        {
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "UPDATE GasDataCollection SET collectiondatetime=@cdt,value=@val,fireplace=@fp," +
                "createddatetime=@dt,zone1=@z1,zone2=@z2,note=@note WHERE id=@id", connection))
            {
                connection.Open();
                command.Parameters.Add("@cdt", DbType.String).Value = data.CollectionDatetime;
                command.Parameters.Add("@val", DbType.Double).Value = data.Value;
                command.Parameters.Add("@fp", DbType.Int32).Value = data.Fireplace;
                command.Parameters.Add("@dt", DbType.String).Value = DateTime.Now.ToString();
                command.Parameters.Add("@z1", DbType.Double).Value = data.Zone1;
                command.Parameters.Add("@z2", DbType.Double).Value = data.Zone2;
                command.Parameters.Add("@id", DbType.Int32).Value = data.Id;
                command.Parameters.Add("@note", DbType.String).Value = (object)data.memoNote ?? DBNull.Value;
                command.ExecuteNonQuery();
            }
        }

        public void UpdateFireplace(List<DataCollector.GasData> gas)
        {
            if (gas == null)
                throw new ArgumentNullException(nameof(gas));

            for (int i = 0; i < gas.Count - 1; i++)
                gas[i].Fireplace = gas[i + 1].Fireplace;

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand(
                    "UPDATE GasDataCollection SET fireplace=@fp WHERE id=@id", connection, transaction))
                {
                    var fireplace = command.Parameters.Add("@fp", DbType.Int32);
                    var id = command.Parameters.Add("@id", DbType.Int32);
                    command.Prepare();
                    foreach (var item in gas)
                    {
                        fireplace.Value = item.Fireplace;
                        id.Value = item.Id;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public List<DataCollector.GasData> CalculateUsage(
            DateTime collectionDateTime, double gasCounter, int fireplace,
            double zone1, double zone2, string mNote)
        {
            var result = new List<DataCollector.GasData>();
            var last = GetLastCollectionGasCounter();
            double daysDifference = (collectionDateTime - last.CollectionDatetime).TotalDays;
            if (daysDifference > 1)
            {
                double dailyUsage = (gasCounter - last.Value) / daysDifference;
                for (int i = 1; i <= daysDifference; i++)
                {
                    result.Add(new DataCollector.GasData
                    {
                        CollectionDatetime = last.CollectionDatetime.AddDays(i),
                        Value = last.Value + dailyUsage * i,
                        Fireplace = fireplace,
                        Zone1 = zone1,
                        Zone2 = zone2,
                        automatic = 1,
                        memoNote = mNote
                    });
                }
            }
            else
            {
                result.Add(new DataCollector.GasData
                {
                    CollectionDatetime = collectionDateTime,
                    Value = gasCounter,
                    Fireplace = fireplace,
                    Zone1 = zone1,
                    Zone2 = zone2,
                    automatic = 0,
                    memoNote = mNote
                });
            }
            return result;
        }

        private DataCollector.GasData GetLastCollectionGasCounter()
        {
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "SELECT MAX(collectiondatetime),MAX(value) FROM GasDataCollection", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read() || reader.IsDBNull(1))
                        throw new InvalidOperationException("Brak poprzedniego odczytu licznika gazu.");

                    return new DataCollector.GasData
                    {
                        CollectionDatetime = reader.IsDBNull(0) ? new DateTime(2000, 1, 1) : ParseDatabaseDate(reader.GetString(0)),
                        Value = reader.GetDouble(1)
                    };
                }
            }
        }

        public List<DataCollector.Prices> GetPrices(DateTime datetime)
        {
            var result = new List<DataCollector.Prices>();
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "SELECT id,key,value,month,year FROM Prices WHERE month=@month AND year=@year", connection))
            {
                connection.Open();
                command.Parameters.Add("@month", DbType.Int32).Value = datetime.Month;
                command.Parameters.Add("@year", DbType.Int32).Value = datetime.Year;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DataCollector.Prices
                        {
                            id = reader.GetInt32(0),
                            key = reader.GetString(1),
                            value = reader.GetDouble(2),
                            month = reader.GetInt32(3),
                            year = reader.GetInt32(4)
                        });
                    }
                }
            }
            return result;
        }

        public List<DataCollector.Prices> GasUsageAndPriceCalculation(DateTime datetime)
        {
            var prices = GetPrices(datetime);
            var gasUsage = GetGasUsage();
            double maxCounterValue = gasUsage.Select(item => item.Value).DefaultIfEmpty().Max();
            gasUsage.AddRange(GetGasUsageBevorConterExchange());

            var monthlyUsage = gasUsage
                .Where(item => item.Month == datetime.Month && item.Year == datetime.Year)
                .ToList();
            if (monthlyUsage.Count == 0)
                throw new InvalidOperationException("Brak odczytów gazu dla wybranego miesiąca.");

            DateTime previousDay = monthlyUsage.Min(item => item.CollectionDatetime).AddDays(-1);
            monthlyUsage.AddRange(gasUsage.Where(item => item.CollectionDatetime == previousDay));
            monthlyUsage = monthlyUsage.OrderBy(item => item.CollectionDatetime).ToList();

            var distribution = prices.FirstOrDefault(item => item.key == "DYSTRYBUCJA_ZMIENNA");
            var fuel = prices.FirstOrDefault(item => item.key == "PALIWO");
            var subscription = prices.FirstOrDefault(item => item.key == "ABONAMENT");
            if (distribution == null || fuel == null || subscription == null)
                throw new InvalidOperationException("Brak kompletu cen dla wybranego miesiąca.");

            int daysInMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month);
            double averageDailyUsage = monthlyUsage.Where(item => item.Usage > 0)
                .Select(item => item.Usage).DefaultIfEmpty().Average();
            // Keep the existing billing boundary and positive-only average.
            double summaryUsage = monthlyUsage
                .Where(item => item.CollectionDatetime < new DateTime(datetime.Year, datetime.Month, daysInMonth))
                .Sum(item => item.Usage);
            double forecastOfUsage = averageDailyUsage * daysInMonth;
            double forecastOfCost = forecastOfUsage * distribution.value +
                forecastOfUsage * fuel.value + subscription.value;

            return new List<DataCollector.Prices>
            {
                new DataCollector.Prices { description = "Sumaryczne zużycie [m3]", id = 1, value = summaryUsage },
                new DataCollector.Prices { description = "Średnie zużycie dzienne [m3]", id = 2, value = averageDailyUsage },
                new DataCollector.Prices { description = "Prognozowany koszt [pln]", id = 3, value = forecastOfCost },
                new DataCollector.Prices { description = "Prognozowane zużycie [m3]", id = 4, value = forecastOfUsage },
                new DataCollector.Prices { description = "Ostatnie wskazanie licznika [m3]", id = 5, value = maxCounterValue }
            };
        }
    }
}
