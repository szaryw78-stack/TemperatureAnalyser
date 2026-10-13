using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TemperatureAnalyser
{
    //public class ApplicationConfig
    //{
    //    private SQLiteConnection connection;

    //    public ApplicationConfig()
    //    {
    //        connection = new SQLiteConnection("Data Source = " + AppDomain.CurrentDomain.BaseDirectory + @"Data\baza.db");
    //    }

    //    private DateTime DateTimeConverter(string dt)
    //    {
    //        DateTime result = DateTime.Now;
    //        try
    //        {
    //            //if (DateTime.TryParse(dt,out))
    //            //{

    //            //}
    //        } catch(Exception ex)
    //        {
    //            throw;
    //        }

    //        return result;
    //    }

    //    public List<DataCollector.TemperaturesData> GetTemperaturesGPT()
    //    {
    //        var result = new List<DataCollector.TemperaturesData>();

    //        string cmdText = @"SELECT id, timestamp, datetime, value 
    //                   FROM TemperatureData 
    //                   ORDER BY timestamp DESC";

    //        string[] formats = { "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:mm:ss" };

    //        try
    //        {
    //            connection.Open();

    //            using(var select = new SQLiteCommand(cmdText, connection))
    //            {
    //                using(var dr = select.ExecuteReader())
    //                {
    //                    while(dr.Read())
    //                    {
    //                        string dateStr = dr.GetString(2);

    //                        DateTime parsedDate = DateTime.ParseExact(
    //                            dateStr,
    //                            formats,
    //                            CultureInfo.InvariantCulture,
    //                            DateTimeStyles.None);

    //                        result.Add(new DataCollector.TemperaturesData
    //                        {
    //                            Id = dr.GetInt32(0),
    //                            TimeStamp = dr.GetDouble(1),
    //                            DateAndTime = parsedDate,
    //                            Temperature = dr.GetDouble(3),
    //                            Date = parsedDate.Date
    //                        });
    //                    }
    //                }
    //            }
    //        } finally
    //        {
    //            connection?.Close();
    //        }

    //        return result;
    //    }

    //    public List<DataCollector.TemperaturesData> GetTemperatures()
    //    {
    //        var result = new List<DataCollector.TemperaturesData>();
    //        // string cmdText = "SELECT id,timestamp,datetime,value FROM TemperatureData  ORDER BY timestamp DESC ";
    //        string cmdText = "SELECT id,timestamp,datetime,value FROM TemperatureData   ";
    //        SQLiteDataReader dr = null;
    //        //int counter = 0;
    //        //string str = string.Empty;
    //        try
    //        {
    //            //string dt = "30.05.2022 11:42:42";
    //            //string dt3 = "2022-05-30 11:42:41";
    //            //DateTime dt2;
    //            // string[] formats = { "yyyy-MM-dd hh:mm:ss","dd.MM.yyyy hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
    //            string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:MM:ss" };

    //            //var dt1 = DateTime.ParseExact(dt3,
    //            //                            formats,
    //            //                            new CultureInfo("pl-PL"),
    //            //                            DateTimeStyles.None);


    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);

    //            //string[] culture = { "pl-PL" };
    //           // CultureInfo ci = new CultureInfo("pl-PL");


    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    // counter++;
    //                    //if (dr.GetString(2).Contains('.'))
    //                    //{

    //                    //}
    //                    // str = dr.GetString(2);
    //                    DateTime dt = DateTime.ParseExact(dr.GetString(2),
    //                                                formats,
    //                                                new CultureInfo("pl-PL"),
    //                                                DateTimeStyles.None);

    //                    var tmp = new DataCollector.TemperaturesData
    //                    {
    //                        Id = dr.GetInt32(0),
    //                        TimeStamp = dr.GetDouble(1),
    //                        DateAndTime = Convert.ToDateTime(dr.GetString(2)),// Convert.ToDateTime(dt), //Convert.ToDateTime(dr.GetString(2),ci),
    //                        Temperature = dr.GetDouble(3),
    //                        Date = Convert.ToDateTime(dr.GetString(2)).Date //Convert.ToDateTime(dt).Date
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            //int c = counter ;
    //            //string str1 = str;
    //            throw ex;
    //        } finally
    //        {
    //            // dr?.Close();
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    public List<DataCollector.TemperaturesData> GetTemperatures(DateTime dStart, DateTime dEnd)
    //    {
    //        var result = new List<DataCollector.TemperaturesData>();
    //        string cmdText = "SELECT id,timestamp,datetime,value FROM TemperatureData  WHERE datetime>=@dStart AND datetime<=@dEnd ORDER BY timestamp DESC ";
    //        SQLiteDataReader dr = null;
    //        //int counter = 0;
    //        //string str = string.Empty;
    //        try
    //        {
    //            //string dt = "30.05.2022 11:42:42";
    //            //string dt3 = "2022-05-30 11:42:41";
    //            //DateTime dt2;
    //            // string[] formats = { "yyyy-MM-dd hh:mm:ss","dd.MM.yyyy hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
    //            string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:MM:ss" };

    //            //var dt1 = DateTime.ParseExact(dt3,
    //            //                            formats,
    //            //                            new CultureInfo("pl-PL"),
    //            //                            DateTimeStyles.None);


    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);
    //            select.Parameters.Add("@dStart", System.Data.DbType.String).Value = dStart.ToString();
    //            select.Parameters.Add("@dEnd", System.Data.DbType.String).Value = dEnd.ToString();


    //            //string[] culture = { "pl-PL" };
    //            // CultureInfo ci = new CultureInfo("pl-PL");


    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    // counter++;
    //                    //if (dr.GetString(2).Contains('.'))
    //                    //{

    //                    //}
    //                    // str = dr.GetString(2);
    //                    DateTime dt = DateTime.ParseExact(dr.GetString(2),
    //                                                formats,
    //                                                new CultureInfo("pl-PL"),
    //                                                DateTimeStyles.None);

    //                    var tmp = new DataCollector.TemperaturesData
    //                    {
    //                        Id = dr.GetInt32(0),
    //                        TimeStamp = dr.GetDouble(1),
    //                        DateAndTime = Convert.ToDateTime(dr.GetString(2)),// Convert.ToDateTime(dt), //Convert.ToDateTime(dr.GetString(2),ci),
    //                        Temperature = dr.GetDouble(3),
    //                        Date = Convert.ToDateTime(dr.GetString(2)).Date //Convert.ToDateTime(dt).Date
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            //int c = counter ;
    //            //string str1 = str;
    //            throw ex;
    //        } finally
    //        {
    //            // dr?.Close();
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    private double GetMaxTimeStampId()
    //    {
    //        string cmdText = "SELECT MAX(timestamp) FROM TemperatureData ";
    //        double maxId = -1;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
    //            var tmp = insert.ExecuteScalar();
    //            if(Convert.DBNull != tmp)
    //            {
    //                maxId = Convert.ToDouble(tmp);
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //        return maxId;
    //    }

    //    public void InsertTemperatures(List<DataCollector.TemperaturesData> temperatures)
    //    {
    //        string cmdText = "INSERT INTO TemperatureData (timestamp,datetime,value) VALUES(@timestamp,@datetime,@value)   ";

    //        try
    //        {
    //            double maxTimeStamp = GetMaxTimeStampId();
    //            connection.Open();

    //            string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:MM:ss", "dd.MM.yyyy HH:MM:ss", "yyyy-MM-dd HH:mm:ss" };

    //            CultureInfo ci = CultureInfo.InvariantCulture;
    //            var sorted = temperatures.Where(c => c.TimeStamp > maxTimeStamp).ToList();
    //            foreach(var i in sorted)
    //            {
    //                DateTime _dateTime = DateTime.ParseExact(i.DateAndTime.ToString(),
    //                                           formats,
    //                                           ci,//new CultureInfo("pl-PL"),
    //                                           DateTimeStyles.None);
    //                if(i.TimeStamp == 1678967485)
    //                {
    //                }

    //                SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
    //                insert.Parameters.Add("@timestamp", System.Data.DbType.Double).Value = i.TimeStamp;
    //                insert.Parameters.Add("@datetime", System.Data.DbType.String).Value = i.DateAndTime;// _dateTime;
    //                insert.Parameters.Add("@value", System.Data.DbType.Double).Value = i.Temperature;
    //                insert.ExecuteNonQuery();
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //    }

    //    public void InsertGasUsage(List<DataCollector.GasData> data)
    //    {
    //        string cmdText = "INSERT INTO GasDataCollection (collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note) VALUES(@collectiondatetime,@value,@fireplace,@createddatetime,@zone1,@zone2,@automatic,@note) ";
    //        try
    //        {
    //            connection.Open();
    //            foreach(var i in data)
    //            {
    //                SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
    //                insert.Parameters.Add("@collectiondatetime", System.Data.DbType.String).Value = i.CollectionDatetime.ToString();
    //                insert.Parameters.Add("@value", System.Data.DbType.Double).Value = i.Value;
    //                insert.Parameters.Add("@fireplace", System.Data.DbType.Int32).Value = i.Fireplace.ToString();
    //                insert.Parameters.Add("@createddatetime", System.Data.DbType.String).Value = DateTime.Now.ToString();
    //                insert.Parameters.Add("@zone1", System.Data.DbType.Double).Value = i.Zone1;
    //                insert.Parameters.Add("@zone2", System.Data.DbType.Double).Value = i.Zone2;
    //                insert.Parameters.Add("@automatic", System.Data.DbType.Int32).Value = i.automatic;
    //                insert.Parameters.Add("@note", System.Data.DbType.String).Value = i.memoNote;


    //                insert.ExecuteNonQuery();
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //    }

    //    public void InsertPrices(List<DataCollector.Prices> prices, DateTime dt)
    //    {
    //        string cmdText = "INSERT INTO Prices (key,value,month,year,createdDatetime) VALUES(@key,@value,@month,@year,@createdDatetime) ";
    //        try
    //        {
    //            connection.Open();
    //            foreach(var i in prices)
    //            {
    //                SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
    //                insert.Parameters.Add("@key", System.Data.DbType.String).Value = i.key;
    //                insert.Parameters.Add("@value", System.Data.DbType.Double).Value = i.value;
    //                insert.Parameters.Add("@month", System.Data.DbType.Int32).Value = dt.Month;
    //                insert.Parameters.Add("@year", System.Data.DbType.Int32).Value = dt.Year;
    //                insert.Parameters.Add("@createdDatetime", System.Data.DbType.String).Value = DateTime.Now;
    //                insert.ExecuteNonQuery();
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //    }

    //    public List<DataCollector.GasData> GetGasUsageFromFile(string path)
    //    {
    //        var result = new List<DataCollector.GasData>();
    //        try
    //        {
    //            if(File.Exists(path))
    //            {
    //                string[] fileLen = File.ReadAllLines(path, System.Text.Encoding.Default);
    //                for(int i = 1; i < fileLen.Length; i++)
    //                {
    //                    var splited = fileLen[i].Split(';');


    //                    //var p = splited[0];


    //                    //DateTime dt = Convert.ToDateTime(splited[0]);
    //                    //double val = Convert.ToDouble(splited[1]);


    //                    var tmp = new DataCollector.GasData
    //                    {
    //                        CollectionDatetime = Convert.ToDateTime(splited[0]),
    //                        Value = Convert.ToDouble(splited[1]),
    //                        Fireplace = Convert.ToInt32(splited[2])
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw;
    //        }


    //        return result;
    //    }

    //    public List<DataCollector.TemperaturesData> GetTemperatureFile(string path)
    //    {
    //        var result = new List<DataCollector.TemperaturesData>();

    //        try
    //        {
    //            if(File.Exists(path))
    //            {
    //                string[] fileLen = File.ReadAllLines(path, System.Text.Encoding.Default);
    //                for(int i = 1; i < fileLen.Length; i++)
    //                {
    //                    var splited = fileLen[i].Split(',');


    //                    var tmp = new DataCollector.TemperaturesData
    //                    {
    //                        TimeStamp = Convert.ToInt64(splited[0]),
    //                        DateAndTime = Convert.ToDateTime(splited[1].Replace('"', ' ')),
    //                        Temperature = Convert.ToDouble(splited[2].Replace('.', ',')),
    //                        Date = (Convert.ToDateTime(splited[1].Replace('"', ' '))).Date,
    //                        TimeSpan = new TimeSpan(Convert.ToDateTime(splited[1].Replace('"', ' ')).Hour, Convert.ToDateTime(splited[1].Replace('"', ' ')).Minute, Convert.ToDateTime(splited[1].Replace('"', ' ')).Second)
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        }


    //        return result;
    //    }

    //    public List<DataCollector.TemperaturesData> AvarageTemperatures(List<DataCollector.TemperaturesData> data)
    //    {
    //        return data
    //            .GroupBy(item => item.Date.Date)
    //            .Select(group => new DataCollector.TemperaturesData
    //            {
    //                Date = group.Key,
    //                AvarageDailyTemperature = group.Average(item => item.Temperature)
    //            })
    //            .OrderBy(item => item.Date)
    //            .ToList();
    //    }

    //    public List<DataCollector.GasData> GetGasUsage()
    //    {
    //        var result = new List<DataCollector.GasData>();
    //        string cmdText = "SELECT id,collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note FROM GasDataCollection ORDER BY collectiondatetime  ";
    //        SQLiteDataReader dr = null;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);

    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    var tmp = new DataCollector.GasData
    //                    {
    //                        Id = dr.GetInt32(0),
    //                        CollectionDatetime = Convert.ToDateTime(dr.GetString(1)),
    //                        Value = dr.GetDouble(2),
    //                        Fireplace = dr.GetInt32(3),
    //                        CreatedDatetime = Convert.ToDateTime(dr.GetString(4)),
    //                        Month = Convert.ToDateTime(dr.GetString(1)).Month,
    //                        Year = Convert.ToDateTime(dr.GetString(1)).Year,
    //                        Zone1 = dr.IsDBNull(5) ? 0 : dr.GetDouble(5),
    //                        Zone2 = dr.IsDBNull(6) ? 0 : dr.GetDouble(6),
    //                        automatic = dr.GetInt32(7),
    //                        memoNote = dr.IsDBNull(8) ? string.Empty : dr.GetString(8)
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }

    //            for(int i = 0; i < result.Count - 1; i++)
    //            {
    //                result[i].Usage = Math.Round((result[i + 1].Value - result[i].Value), 1);
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    public List<DataCollector.GasData> GetGasUsageBevorConterExchange()
    //    {
    //        var result = new List<DataCollector.GasData>();
    //        string cmdText = "SELECT id,collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note FROM GasDataCollectionOld ORDER BY collectiondatetime  ";
    //        SQLiteDataReader dr = null;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);

    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    var tmp = new DataCollector.GasData
    //                    {
    //                        Id = dr.GetInt32(0),
    //                        CollectionDatetime = Convert.ToDateTime(dr.GetString(1)),
    //                        Value = dr.GetDouble(2),
    //                        Fireplace = dr.GetInt32(3),
    //                        CreatedDatetime = Convert.ToDateTime(dr.GetString(4)),
    //                        Month = Convert.ToDateTime(dr.GetString(1)).Month,
    //                        Year = Convert.ToDateTime(dr.GetString(1)).Year,
    //                        Zone1 = dr.IsDBNull(5) ? 0 : dr.GetDouble(5),
    //                        Zone2 = dr.IsDBNull(6) ? 0 : dr.GetDouble(6),
    //                        automatic = dr.GetInt32(7),
    //                        memoNote = dr.IsDBNull(8) ? string.Empty : dr.GetString(8)
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }

    //            for(int i = 0; i < result.Count - 1; i++)
    //            {
    //                result[i].Usage = Math.Round((result[i + 1].Value - result[i].Value), 1);
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    public List<DataCollector.GasData> GetGasUsage(DateTime dStart, DateTime dEnd)
    //    {
    //        var result = new List<DataCollector.GasData>();
    //        string cmdText = "SELECT id,collectiondatetime,value,fireplace,createddatetime,zone1,zone2,automatic,note FROM GasDataCollection " +
    //            " WHERE collectiondatetime>='@dStart' AND collectiondatetime<='@dEnd' ORDER BY collectiondatetime  ";
    //        SQLiteDataReader dr = null;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);
    //            select.Parameters.Add("@dStart", System.Data.DbType.String).Value = dStart.ToString();
    //            select.Parameters.Add("@dEnd", System.Data.DbType.String).Value = dEnd.ToString();


    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    var tmp = new DataCollector.GasData
    //                    {
    //                        Id = dr.GetInt32(0),
    //                        CollectionDatetime = Convert.ToDateTime(dr.GetString(1)),
    //                        Value = dr.GetDouble(2),
    //                        Fireplace = dr.GetInt32(3),
    //                        CreatedDatetime = Convert.ToDateTime(dr.GetString(4)),
    //                        Month = Convert.ToDateTime(dr.GetString(1)).Month,
    //                        Year = Convert.ToDateTime(dr.GetString(1)).Year,
    //                        Zone1 = dr.IsDBNull(5) ? 0 : dr.GetDouble(5),
    //                        Zone2 = dr.IsDBNull(6) ? 0 : dr.GetDouble(6),
    //                        automatic = dr.GetInt32(7),
    //                        memoNote = dr.IsDBNull(8) ? string.Empty : dr.GetString(8)
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }

    //            for(int i = 0; i < result.Count - 1; i++)
    //            {
    //                result[i].Usage = Math.Round((result[i + 1].Value - result[i].Value), 1);
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    public DataCollector.GasData GetTemperatureSettings()
    //    {
    //        var result = new DataCollector.GasData();
    //        string cmdText = "SELECT  zone1,zone2 FROM GasDataCollection ORDER BY Id DESC  LIMIT 1 ";
    //        SQLiteDataReader dr = null;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);

    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    result.Zone1 = dr.GetDouble(0);
    //                    result.Zone2 = dr.GetDouble(1);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }

    //        return result;
    //    }

    //    public void UpdateGasUsage(DataCollector.GasData data)
    //    {
    //        string cmdText = "UPDATE GasDataCollection SET collectiondatetime=@cdt,value=@val,fireplace=@fp,createddatetime=@dt,zone1=@z1,zone2=@z2,note=@note WHERE id=@id";
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand update = new SQLiteCommand(cmdText, connection);
    //            update.Parameters.Add("@cdt", System.Data.DbType.String).Value = data.CollectionDatetime;
    //            update.Parameters.Add("@val", System.Data.DbType.Double).Value = data.Value;
    //            update.Parameters.Add("@fp", System.Data.DbType.Int32).Value = data.Fireplace;
    //            update.Parameters.Add("@dt", System.Data.DbType.String).Value = DateTime.Now.ToString();
    //            update.Parameters.Add("@z1", System.Data.DbType.Double).Value = data.Zone1;
    //            update.Parameters.Add("@z2", System.Data.DbType.Double).Value = data.Zone2;
    //            update.Parameters.Add("@id", System.Data.DbType.Int32).Value = data.Id;
    //            update.Parameters.Add("@note", System.Data.DbType.String).Value = data.memoNote;
    //            update.ExecuteNonQuery();
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //    }

    //    public void UpdateFireplace(List<DataCollector.GasData> gas)
    //    {
    //        string cmdText = "UPDATE GasDataCollection SET fireplace=@fp WHERE id=@id ";

    //        for(int i = 0; i < gas.Count - 1; i++)
    //        {
    //            gas[i].Fireplace = gas[i + 1].Fireplace;
    //        }
    //        try
    //        {
    //            connection.Open();
    //            foreach(var item in gas)
    //            {
    //                SQLiteCommand update = new SQLiteCommand(cmdText, connection);
    //                update.Parameters.Add("@fp", System.Data.DbType.Int32).Value = item.Fireplace;
    //                update.Parameters.Add("@id", System.Data.DbType.Int32).Value = item.Id;
    //                update.ExecuteNonQuery();
    //            }


    //            //SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
    //            //insert.Parameters.Add("@collectiondatetime", System.Data.DbType.String).Value = i.CollectionDatetime.ToString();
    //            //insert.Parameters.Add("@value", System.Data.DbType.Double).Value = i.Value;
    //            //insert.Parameters.Add("@fireplace", System.Data.DbType.Int32).Value = i.Fireplace.ToString();
    //            //insert.Parameters.Add("@createddatetime", System.Data.DbType.String).Value = DateTime.Now.ToString();
    //        } catch(Exception)
    //        {
    //            throw;
    //        } finally
    //        {
    //            connection?.Close();
    //        }
    //    }

    //    public List<DataCollector.GasData> CalculateUsage(DateTime collectionDateTime, double gasCounter, int fireplace, double zone1, double zone2, string mNote)
    //    {
    //        var result = new List<DataCollector.GasData>();
    //        try
    //        {
    //            var lastGasuUsageValues = GetLastCollectionGasCounter();
    //            DateTime lastCollectionDateTime = lastGasuUsageValues.CollectionDatetime;
    //            double daysDifference = (collectionDateTime - lastCollectionDateTime).TotalDays;
    //            double gasUsage = gasCounter - lastGasuUsageValues.Value;
    //            double lastVal = lastGasuUsageValues.Value;
    //            double value = 0;
    //            double dailyUsage = gasUsage / daysDifference;


    //            if(daysDifference > 1)
    //            {
    //                for(int i = 1; i <= daysDifference; i++)
    //                {
    //                    value = 0;
    //                    DateTime dt = lastCollectionDateTime.AddDays(i);
    //                    value = lastVal + dailyUsage * i;


    //                    var tmp = new DataCollector.GasData
    //                    {
    //                        CollectionDatetime = dt,
    //                        Value = value,
    //                        Fireplace = fireplace,
    //                        Zone1 = zone1,
    //                        Zone2 = zone2,
    //                        automatic = 1,
    //                        memoNote = mNote //string.Empty
    //                    };
    //                    result.Add(tmp);
    //                }
    //            } else
    //            {
    //                var tmp = new DataCollector.GasData
    //                {
    //                    CollectionDatetime = collectionDateTime,
    //                    Value = gasCounter,
    //                    Fireplace = fireplace,
    //                    Zone1 = zone1,
    //                    Zone2 = zone2,
    //                    automatic = 0,
    //                    memoNote = mNote
    //                };
    //                result.Add(tmp);


    //                //dla różnicy 1 dnia czyli rejestracja codziennie
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        }


    //        return result;
    //    }

    //    private DataCollector.GasData GetLastCollectionGasCounter()
    //    {
    //        var result = new DataCollector.GasData();
    //        string cmdText = "SELECT  MAX(collectiondatetime),MAX(value) FROM GasDataCollection ";
    //        SQLiteDataReader dr = null;
    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);

    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                dr.Read();
    //                result.CollectionDatetime = dr.IsDBNull(0) ? new DateTime(2000, 1, 1) : dr.GetDateTime(0);
    //                result.Value = dr.GetDouble(1);
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }
    //        return result;
    //    }

    //    public List<DataCollector.Prices> GetPrices(DateTime datetime)
    //    {
    //        var result = new List<DataCollector.Prices>();

    //        string cmdText = "SELECT id,key,value,month,year,createdDatetime FROM Prices WHERE month=@month AND year=@year ";
    //        SQLiteDataReader dr = null;

    //        try
    //        {
    //            connection.Open();
    //            SQLiteCommand select = new SQLiteCommand(cmdText, connection);
    //            select.Parameters.Add("@month", System.Data.DbType.Int32).Value = datetime.Month;
    //            select.Parameters.Add("@year", System.Data.DbType.Int32).Value = datetime.Year;

    //            dr = select.ExecuteReader();
    //            if(dr.HasRows)
    //            {
    //                while(dr.Read())
    //                {
    //                    var tmp = new DataCollector.Prices
    //                    {
    //                        id = dr.GetInt32(0),
    //                        key = dr.GetString(1),
    //                        value = dr.GetDouble(2),
    //                        month = dr.GetInt32(3),
    //                        year = dr.GetInt32(4),
    //                    };
    //                    result.Add(tmp);
    //                }
    //            }
    //        } catch(Exception ex)
    //        {
    //            throw ex;
    //        } finally
    //        {
    //            dr?.Close();
    //            connection?.Close();
    //        }


    //        return result;
    //    }

    //    //private List<DataCollector.Prices> Definition()
    //    //{
    //    //    var result = new List<DataCollector.Prices>();

    //    //    result.Add(new DataCollector.Prices { description = "Bieżące zużycie", id = 1 });
    //    //    result.Add(new DataCollector.Prices { description = "Średnie zużycie", id = 2 });
    //    //    result.Add(new DataCollector.Prices { description = "Prognozowany koszt", id = 3 });


    //    //    return result;
    //    //}

    //    public List<DataCollector.Prices> GasUsageAndPriceCalculation(DateTime datetime)
    //    {
    //        var result = new List<DataCollector.Prices>();
    //        try
    //        {
    //            // result = Definition();
    //            var prices = GetPrices(datetime).Where(i => i.year == datetime.Year && i.month == datetime.Month).ToList();
    //            var gasUsage = GetGasUsage();
    //            var gasUsageBevorCounterExchange = GetGasUsageBevorConterExchange();
    //            int daysInMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month);
    //            var maxCounterValue = gasUsage.Select(i => i.Value).DefaultIfEmpty().Max();
    //            //int currentDayCount = DateTime.Now.Day;

    //            gasUsage.AddRange(gasUsageBevorCounterExchange);

    //            var gasUsageCurrentSelectedMonth = gasUsage.Where(i => i.Month == datetime.Month && i.Year == datetime.Year).ToList();
    //            //var lastDayInPreviousMonth = gasUsage.Where(i=>i.)
    //            var lastDayUsageInPreviousMonth = gasUsage.Where(i => i.CollectionDatetime == gasUsageCurrentSelectedMonth.Select(c => c.CollectionDatetime).Min().AddDays(-1)).ToList();
    //            gasUsageCurrentSelectedMonth.AddRange(lastDayUsageInPreviousMonth);

    //            var gasUsage1 = gasUsageCurrentSelectedMonth.OrderBy(i => i.CollectionDatetime).ToList();
    //            var currentDayCount = 1;
    //            if(DateTime.Now.Month != datetime.Month)
    //            {
    //                currentDayCount = daysInMonth;
    //            } else
    //            {
    //                currentDayCount = DateTime.Now.Day;
    //            }

    //            var avarageDailyUsage = gasUsage1.Where(i => i.Usage > 0).Select(i => i.Usage).DefaultIfEmpty().Average();//Sum() / currentDayCount;
    //            // var avagageMonthlyTemperature = GetTemperatures().Where(i=>i.)


    //            var summaryUsage = gasUsage1.Where(i => i.CollectionDatetime < new DateTime(datetime.Year, datetime.Month, daysInMonth)).Select(i => i.Usage).DefaultIfEmpty().Sum();
    //            var d1 = (avarageDailyUsage * daysInMonth) * prices.Where(i => i.key == "DYSTRYBUCJA_ZMIENNA").Select(i => i.value).FirstOrDefault();
    //            var d2 = avarageDailyUsage * daysInMonth * prices.Where(i => i.key == "PALIWO").Select(i => i.value).FirstOrDefault();
    //            var d3 = prices.Where(i => i.key == "ABONAMENT").Select(i => i.value).FirstOrDefault();

    //            var forecastOfCost = d1 + d2 + d3;
    //            var forecastOfUsage = avarageDailyUsage * daysInMonth;


    //            result.Add(new DataCollector.Prices
    //            {
    //                description = "Sumaryczne zużycie [m3]",
    //                id = 1,
    //                value = summaryUsage
    //            });
    //            result.Add(new DataCollector.Prices
    //            {
    //                description = "Średnie zużycie dzienne [m3]",
    //                id = 2,
    //                value = avarageDailyUsage
    //            });
    //            result.Add(new DataCollector.Prices
    //            {
    //                description = "Prognozowany koszt [pln]",
    //                id = 3,
    //                value = forecastOfCost
    //            });
    //            result.Add(new DataCollector.Prices
    //            {
    //                description = "Prognozowane zużycie [m3]",
    //                id = 4,
    //                value = forecastOfUsage
    //            });
    //            result.Add(new DataCollector.Prices
    //            {
    //                description = "Ostatnie wskazanie licznika [m3]",
    //                id = 5,
    //                value = maxCounterValue
    //            });
    //        } catch(Exception ex)
    //        {
    //            throw;
    //        }


    //        return result;
    //    }
    //}
}
