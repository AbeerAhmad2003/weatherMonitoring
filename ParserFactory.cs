using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1
{
    public static class ParserFactory
    {
        public static IWeatherDataParser Create(string type)
        {
            return type.ToLower() switch
            {
                "json" => new JsonWeatherDataParser(),
                "xml" => new XmlWeatherParser(),
                _ => throw new ArgumentException("Unsupported parser type.")
            };
        }
    }
}
