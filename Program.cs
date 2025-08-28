using weatherProj1.BotSimpleFactory;
using weatherProj1.DataParsing;

namespace weatherProj1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "botsConfig.json");
            string configJson = File.ReadAllText(configPath);
            var bots = BotFactory.CreateBots(configJson);
            var station = new WeatherStation();
        
            foreach (var bot in bots)
            {
                station.RegisterBot(bot);
            }
            string weatherJson = @"{
              ""Location"": ""Tulkarem"",
              ""Temperature"": 32,
              ""Humidity"": 75
            }";
            ParserCreator parserCreator = ParserFactory.CreateParser(weatherJson);

            IWeatherDataParser parser = parserCreator.CreateParser();
            WeatherData? data = parser.Parse(weatherJson);

            if (data != null)
            {
                station.Notify(data);
            }



        }
    }
}
