using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    throw new ArgumentNullException("Location cannot be empty.");
                _location = value;
            }
        }
        public double Temperature
        {
            get => _temperature;
            set
            {
                if (value < -100 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Temperature), "Temperature out of range.");
                _temperature = value;
            }
        }

        public double Humidity
        {
            get => _humidity;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Humidity), "Humidity must be between 0 and 100.");
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

