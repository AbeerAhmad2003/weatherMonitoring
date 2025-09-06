using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1.BotSimpleFactory
{
    public interface IWeatherBot
    {
        void Update(WeatherData data);

    }
}
