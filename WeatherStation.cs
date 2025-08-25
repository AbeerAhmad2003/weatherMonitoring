using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherProj1.BotSimpleFactory;

namespace weatherProj1
{
    public class WeatherStation
    {
        private readonly List<IWeatherBot> _bots = new List<IWeatherBot>();

        public void RegisterBot(IWeatherBot bot)
        {
            if (bot == null) throw new ArgumentNullException(nameof(bot));
            _bots.Add(bot);
        }

        public void RemoveBot(IWeatherBot bot) => _bots.Remove(bot);

        public void Notify(WeatherData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            foreach (var bot in _bots)
            {
                bot.Update(data);
            }
        }
    }
}
