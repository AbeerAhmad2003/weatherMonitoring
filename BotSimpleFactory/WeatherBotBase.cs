using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1.BotSimpleFactory
{
    public abstract class WeatherBotBase : IWeatherBot
    {
        protected BotConfig Config;
        protected string Name;

        protected WeatherBotBase(string name, BotConfig config)
        {
            Name = name;
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public abstract void Update(WeatherData data);
    }
}
