using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace TemperatureAnalyser
{
    public class GasImprooved
    {
        private SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = " +
                AppDomain.CurrentDomain.BaseDirectory + @"Data\baza.db");
        }

        public List<DataCollector.GasDataImprooved> GetDataImprooveds()
        {
            var result = new List<DataCollector.GasDataImprooved>();
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "SELECT id,realcounter,virtualcounter,createddatetime FROM GasDataCollectionImprooved",
                connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double realCounter = reader.GetDouble(1);
                        double virtualCounter = reader.GetDouble(2);
                        result.Add(new DataCollector.GasDataImprooved
                        {
                            id = reader.GetInt32(0),
                            realcounter = realCounter,
                            virtualcounter = virtualCounter,
                            createdDatetime = ApplicationConfig.ParseDatabaseDate(reader.GetString(3)),
                            difference = virtualCounter - realCounter
                        });
                    }
                }
            }
            return result;
        }

        public void InsertGasImproovement(double realcouter, double virtualcounter, DateTime dt)
        {
            using (var connection = CreateConnection())
            using (var command = new SQLiteCommand(
                "INSERT INTO GasDataCollectionImprooved (realcounter,virtualcounter,createddatetime) " +
                "VALUES(@realcounter,@virtualcounter,@createddatetime)", connection))
            {
                connection.Open();
                command.Parameters.Add("@realcounter", DbType.Double).Value = realcouter;
                command.Parameters.Add("@virtualcounter", DbType.Double).Value = virtualcounter;
                command.Parameters.Add("@createddatetime", DbType.String).Value = dt.ToString();
                command.ExecuteNonQuery();
            }
        }
    }
}
