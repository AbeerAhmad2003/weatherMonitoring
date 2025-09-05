namespace weatherProj1.BotSimpleFactory
{
    public abstract class WeatherBotBase : IWeatherBot
    {
        protected readonly BotConfig Config;
        protected readonly string Name;

        protected WeatherBotBase(string name, BotConfig config)
        {
            Name = name;
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public abstract void Update(WeatherData data);
    }
}
