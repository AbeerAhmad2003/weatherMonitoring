using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace weatherProj1.parserFactoryMethod
{
    public class XmlWeatherParser : IWeatherDataParser
    {
        public WeatherData? Parse(string input)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(input))
                {
                    var data = (WeatherData?)serializer.Deserialize(reader);
                    if (data == null)
                        Console.WriteLine("XML input is empty or invalid.");
                    return data;
                }

            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine($"Invalid XML format: {ex.Message}");
                return null;
            }

        }
    }
}
