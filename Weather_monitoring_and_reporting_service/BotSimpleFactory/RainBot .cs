using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace weatherProj1.BotSimpleFactory
{
    public class RainBot : WeatherBotBase
    {
        public RainBot(BotConfig config) : base("RainBot", config) { }

        public override void Update(WeatherData data)
        {
            if (!Config.Enabled) return;
            if (data.Humidity > Config.Threshold)
            {
                Console.WriteLine($"{Name} activated!");
                Console.WriteLine($"{Name}: \"{Config.Message}\"");
            }
        }
    }
}
