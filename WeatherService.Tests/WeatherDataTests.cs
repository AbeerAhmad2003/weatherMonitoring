using FluentAssertions;
using weatherProj1;

namespace WeatherService
{
    public class WeatherDataTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowArgumentNullExceptionWhenLocationIsNullOrEmpty(string invalidLocation)
        {

            Action act = () => new WeatherData(invalidLocation, 25, 50);

            act.Should().Throw<ArgumentNullException>()
               .And.ParamName.Should().Be(nameof(WeatherData.Location));
        }

        [Theory]
        [InlineData(200)]
        [InlineData(-200)]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenTemperatureOutOfRange(double invalidTemp)
        {
            Action act = () => new WeatherData("Cairo", invalidTemp, 50);
            act.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be(nameof(WeatherData.Temperature));
        }
        [Theory]
        [InlineData(-10)]
        [InlineData(120)]
        public void ShouldThrowArgumentOutOfRangeException_WhenHumidityOutOfRange(double invalidHumidity)
        {
            Action act = () => new WeatherData("Cairo", 25, invalidHumidity);

            act.Should().Throw<ArgumentOutOfRangeException>()
               .And.ParamName.Should().Be(nameof(WeatherData.Humidity));
        }
    }
}
