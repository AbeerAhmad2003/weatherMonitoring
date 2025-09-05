namespace weatherProj1
{
    public class WeatherData
    {
        private string _location;
        private double _temperature;
        private double _humidity;
        public string Location
        {
            get => _location;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Location));
                _location = value;
            }
        }
        public double Temperature
        {
            get => _temperature;
            set
            {
                if (value < -100 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Temperature));
                _temperature = value;
            }
        }
        public double Humidity
        {
            get => _humidity;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Humidity));
                _humidity = value;
            }
        }
        public WeatherData(string location, double temperature, double humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}

