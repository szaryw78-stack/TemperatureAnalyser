using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureAnalyser
{
    public class GasImprooved
    {
        private SQLiteConnection connection;

        public GasImprooved()
        {
            connection = new SQLiteConnection("Data Source = " + AppDomain.CurrentDomain.BaseDirectory + @"Data\baza.db");
        }

        public List<DataCollector.GasDataImprooved> GetDataImprooveds()
        {
            var result = new List   <DataCollector.GasDataImprooved>();
            string cmdText = "SELECT id,realcounter,virtualcounter,createddatetime FROM GasDataCollectionImprooved ";
            SQLiteDataReader dr = null;
            try
            {
                string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };

                connection.Open();
                SQLiteCommand select = new SQLiteCommand(cmdText, connection);

                dr = select.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // counter++;
                        if (dr.GetString(3).Contains('.'))
                        {

                        }
                        // str = dr.GetString(2);
                        DateTime dt = DateTime.ParseExact(dr.GetString(3),
                                                    formats,
                                                    new CultureInfo("pl-PL"),
                                                    DateTimeStyles.None);

                        var tmp = new DataCollector.GasDataImprooved
                        {
                            id = dr.GetInt32(0),
                            realcounter = dr.GetDouble(1),
                            virtualcounter = dr.GetDouble(2),
                            createdDatetime = Convert.ToDateTime(dt), //Convert.ToDateTime(dr.GetString(2),ci),
                            difference = dr.GetDouble(2)- dr.GetDouble(1)


                        };
                        result.Add(tmp);

                    }
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dr?.Close();
                connection?.Close();

            }

            return result;
        }
        public void InsertGasImproovement(double realcouter,double virtualcounter,DateTime dt)
        {
            string cmdText = "INSERT INTO GasDataCollectionImprooved (realcounter,virtualcounter,createddatetime) VALUES(@realcounter,@virtualcounter,@createddatetime)   ";

            try
            {
                //double maxTimeStamp = GetMaxTimeStampId();
                connection.Open();

               
                    SQLiteCommand insert = new SQLiteCommand(cmdText, connection);
                    insert.Parameters.Add("@realcounter", System.Data.DbType.Double).Value = realcouter;
                    insert.Parameters.Add("@createddatetime", System.Data.DbType.String).Value = dt.ToString();
                    insert.Parameters.Add("@virtualcounter", System.Data.DbType.Double).Value = virtualcounter;
                    insert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection?.Close();
            }

        }

    }
}
