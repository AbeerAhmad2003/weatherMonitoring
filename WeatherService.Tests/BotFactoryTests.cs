using FluentAssertions;
using weatherProj1.BotSimpleFactory;

namespace WeatherService
{
    public class BotFactoryTests
    {

        [Theory]
        [InlineData("{}")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateBots_ShouldReturnEmptyList_WhenConfigIsEmptyOrNull(string configJson)
        {
            var bots = BotFactory.CreateBots(configJson);
            bots.Should().BeEmpty();
        }
        [Fact]
        public void CreateBots_ShouldReturnCorrectBots_WhenConfigHasEnabledBots()
        {
            var configJson = @"{
            ""RainBot"": { ""Enabled"": true, ""Threshold"": 50, ""Message"": ""Rain alert!"" },
            ""SunBot"": { ""Enabled"": true, ""Threshold"": 30, ""Message"": ""Sun alert!"" }
        }";

            var bots = BotFactory.CreateBots(configJson);

            bots.Should().HaveCount(2);
            bots.Should().ContainSingle(b => b is RainBot);
            bots.Should().ContainSingle(b => b is SunBot);
        }
        [Fact]
        public void CreateBots_ShouldSkipDisabledBots()
        {
            var configJson = @"{
            ""RainBot"": { ""Enabled"": false, ""Threshold"": 50, ""Message"": ""Rain alert!"" },
            ""SunBot"": { ""Enabled"": true, ""Threshold"": 30, ""Message"": ""Sun alert!"" }
        }";

            var bots = BotFactory.CreateBots(configJson);

            bots.Should().HaveCount(1);
            bots.Should().ContainSingle(b => b is SunBot);
        }
        [Theory]
        [InlineData("invalid json")]
        [InlineData("{ invalid json }")]
        public void CreateBots_ShouldReturnEmptyList_WhenConfigIsInvalid(string invalidJson)
        {
            var bots = BotFactory.CreateBots(invalidJson);
            bots.Should().BeEmpty();
        }
    }
}
