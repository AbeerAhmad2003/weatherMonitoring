using System.Text.Json;

namespace weatherProj1.BotSimpleFactory
{
    public static class BotFactory
    {
        public static List<WeatherBotBase> CreateBots(string configJson)
        {
            var bots = new List<WeatherBotBase>();
            if (configJson == null) return bots;
            Dictionary<string, BotConfig>? config = null;
            try
            {
                config = JsonSerializer.Deserialize<Dictionary<string, BotConfig>>(configJson);
            }
            catch (JsonException)
            {
                return bots;
            }

            if (config == null) return bots;

            foreach (var entry in config)
            {
                switch (entry.Key)
                {
                    case "RainBot":
                        if (entry.Value.Enabled)
                            bots.Add(new RainBot(entry.Value));
                        break;

                    case "SunBot":
                        if (entry.Value.Enabled)
                            bots.Add(new SunBot(entry.Value));
                        break;

                    case "SnowBot":
                        if (entry.Value.Enabled)
                            bots.Add(new SnowBot(entry.Value));
                        break;
                }
            }

            return bots;
        }
    }
}
