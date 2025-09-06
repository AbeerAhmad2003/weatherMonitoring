using FluentAssertions;
using weatherProj1;
using weatherProj1.BotSimpleFactory;

namespace WeatherService
{
    public class SunBotTests : IDisposable
    {
        private readonly SunBot _botEnabled;
        private readonly SunBot _botDisabled;
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOut;

        public SunBotTests()
        {
            _botEnabled = new SunBot(new BotConfig { Enabled = true, Threshold = 30, Message = "Sun alert!" });
            _botDisabled = new SunBot(new BotConfig { Enabled = false, Threshold = 30, Message = "Sun alert!" });
            _stringWriter = new StringWriter();
            _originalOut = Console.Out;
            Console.SetOut(_stringWriter);
        }

        [Fact]
        public void Update_ShouldActivate_WhenThresholdExceeded()
        {
            var data = new WeatherData("Cairo", 35, 50);
            _botEnabled.Update(data);
            var output = _stringWriter.ToString();
            output.Should().Contain("SunBot activated!");
            output.Should().Contain("Sun alert!");
        }

        [Fact]
        public void Update_ShouldNotActivate_WhenDisabled()
        {
            var data = new WeatherData("Cairo", 35, 50);
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
            Action act = () => new SunBot(null);
            act.Should().Throw<ArgumentNullException>();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
            _stringWriter.Dispose();
        }
    }
}
