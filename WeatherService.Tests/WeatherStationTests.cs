using FluentAssertions;
using Moq;
using weatherProj1;
using weatherProj1.BotSimpleFactory;

namespace WeatherService
{
    public class WeatherStationTests
    {
        private readonly WeatherStation _station;

        public WeatherStationTests()
        {
            _station = new WeatherStation();
        }
        [Fact]
        public void RegisterBot_ShouldAddBotToList()
        {
            var mockBot = new Mock<IWeatherBot>();
            _station.RegisterBot(mockBot.Object);
            var data = new WeatherData("Cairo", 25, 50);
            mockBot.Verify(b => b.Update(It.IsAny<WeatherData>()), Times.Never);
            _station.Notify(data);
            mockBot.Verify(b => b.Update(data), Times.Once);
        }
        [Fact]
        public void RemoveBot_ShouldRemoveBotFromList()
        {
            var mockBot = new Mock<IWeatherBot>();
            _station.RegisterBot(mockBot.Object);
            _station.RemoveBot(mockBot.Object);
            var data = new WeatherData("Cairo", 25, 50);
            _station.Notify(data);
            mockBot.Verify(b => b.Update(It.IsAny<WeatherData>()), Times.Never);

        }
        [Fact]
        public void Notify_ShouldThrow_WhenDataIsNull()
        {
            Action act = () => _station.Notify(null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
