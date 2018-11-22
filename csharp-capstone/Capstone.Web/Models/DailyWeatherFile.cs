using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DailyWeatherFile
    {
        
        public string ParkCode { get; set; }

        public int Day { get; set; }

        public int Low { get; set; }

        public int High { get; set; }

        public string Forecast { get; set; }

        public string Degree { get; set; } = "F";

        public int ConvertToCelcius(double num)
        {
            double celsius = 0;
            celsius = (((num - 32) * 5) / 9);
            return (int)celsius;
        }
        
    }
}
