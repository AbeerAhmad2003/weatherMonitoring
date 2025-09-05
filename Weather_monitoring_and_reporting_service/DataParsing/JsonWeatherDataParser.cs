using System.Text.Json;

namespace weatherProj1.DataParsing
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
