using FluentAssertions;
using weatherProj1;
using weatherProj1.BotSimpleFactory;

namespace WeatherService
{
    public class SnowBotTests : IDisposable
    {
        private readonly SnowBot _botEnabled;
        private readonly SnowBot _botDisabled;
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOut;

        public SnowBotTests()
        {
            _botEnabled = new SnowBot(new BotConfig { Enabled = true, Threshold = 0, Message = "Snow alert!" });
            _botDisabled = new SnowBot(new BotConfig { Enabled = false, Threshold = 0, Message = "Snow alert!" });
            _stringWriter = new StringWriter();
            _originalOut = Console.Out;
            Console.SetOut(_stringWriter);
        }

        [Fact]
        public void Update_ShouldActivate_WhenThresholdExceeded()
        {
            var data = new WeatherData("Cairo", -5, 50);
            _botEnabled.Update(data);
            var output = _stringWriter.ToString();
            output.Should().Contain("SnowBot activated!");
            output.Should().Contain("Snow alert!");
        }

        [Fact]
        public void Update_ShouldNotActivate_WhenDisabled()
        {
            var data = new WeatherData("Cairo", -5, 50);
            _botDisabled.Update(data);
            _stringWriter.ToString().Should().BeEmpty();
        }

        [Fact]
        public void Update_ShouldNotActivate_WhenThresholdNotReached()
        {
            var data = new WeatherData("Cairo", 5, 50);
            _botEnabled.Update(data);
            _stringWriter.ToString().Should().BeEmpty();
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenConfigIsNull()
        {
            Action act = () => new SnowBot(null);
            act.Should().Throw<ArgumentNullException>();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
            _stringWriter.Dispose();
        }
    }
}
