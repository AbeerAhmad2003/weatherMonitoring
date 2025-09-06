using FluentAssertions;
using weatherProj1;
using weatherProj1.BotSimpleFactory;

namespace WeatherService
{
    public class RainBotTests : IDisposable
    {

        private readonly RainBot _botEnabled;
        private readonly RainBot _botDisabled;
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOut;

        public RainBotTests()
        {
            _botEnabled = new RainBot(new BotConfig { Enabled = true, Threshold = 60, Message = "Rain alert!" });
            _botDisabled = new RainBot(new BotConfig { Enabled = false, Threshold = 60, Message = "Rain alert!" });
            _stringWriter = new StringWriter();
            _originalOut = Console.Out;
            Console.SetOut(_stringWriter);
        }
        [Fact]
        public void Update_ShouldActivate_WhenThresholdExceeded()
        {
            var data = new WeatherData("Cairo", 25, 70);
            _botEnabled.Update(data);
            var output = _stringWriter.ToString();
            output.Should().Contain("RainBot activated!");
            output.Should().Contain("Rain alert!");
        }
        [Fact]
        public void Update_ShouldNotActivate_WhenDisabled()
        {
            var data = new WeatherData("Cairo", 25, 70);
            _botDisabled.Update(data);
            _stringWriter.ToString().Should().BeEmpty();
        }
        [Fact]
        public void Update_ShouldNotActivate_WhenThresholdNotReached()
        {
            var data = new WeatherData("Cairo", 25, 50);
            _botEnabled.Update(data);
            _stringWriter.ToString().Should().BeEmpty();
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenConfigIsNull()
        {
            Action act = () => new RainBot(null);
            act.Should().Throw<ArgumentNullException>();
        }
        public void Dispose()
        {

            Console.SetOut(_originalOut);
            _stringWriter.Dispose();
        }
    }
}
