using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{

    public class WeatherSqlDAL : IWeatherSqlDAL
    {
        private readonly string connectionString;

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<DailyWeatherFile> GetWeather(string Id)
        {

            IList<DailyWeatherFile> dailyWeather = new List<DailyWeatherFile>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", Id);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var singleDayWeather = new DailyWeatherFile()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Day = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"]),
                           
                        };

                        dailyWeather.Add(singleDayWeather);
                    }
                }

            }

            catch (SqlException ex)
            {
                throw;
            }

            return dailyWeather;

        }
    }
}

