using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace weatherProj1
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData? Parse(string input)
        {
            try
            {
                var data = JsonSerializer.Deserialize<WeatherData>(input);
                if (data == null)
                {
                    Console.WriteLine("JSON input is empty or invalid.");

                }
                return data;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON format: {ex.Message}");
                return null;
            }
        }
    }
}
