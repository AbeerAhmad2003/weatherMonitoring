using weatherProj1.BotSimpleFactory;
using weatherProj1.parserFactoryMethod;

namespace weatherProj1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string configJson = File.ReadAllText("C:\\Users\\Asus\\Desktop\\weatherProject\\botsConfig.json");
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
            ParserCreator parserCreator = new JsonParserCreator();

            IWeatherDataParser parser = parserCreator.CreateParser();
            WeatherData? data = parser.Parse(weatherJson);

            if (data != null)
            {
                station.Notify(data);
            }



        }
    }
}
