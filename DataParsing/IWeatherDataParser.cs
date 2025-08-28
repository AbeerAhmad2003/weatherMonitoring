using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1.DataParsing
{
    public interface IWeatherDataParser
    {
        public WeatherData? Parse(string input);
    }
}
