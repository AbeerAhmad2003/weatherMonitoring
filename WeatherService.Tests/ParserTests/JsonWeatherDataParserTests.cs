using FluentAssertions;
using weatherProj1;
using weatherProj1.DataParsing;

namespace WeatherService
{
    public class JsonWeatherDataParserTests
    {
        private readonly JsonWeatherDataParser _parser;

        public JsonWeatherDataParserTests()
        {
            _parser = new JsonWeatherDataParser();
        }

        [Fact]
        public void Parse_ShouldReturnWeatherData_WhenJsonIsValid()
        {
            string json = @"{
                ""Location"": ""Amman"",
                ""Temperature"": 20,
                ""Humidity"": 60
            }";
            var result = _parser.Parse(json);
            result.Should().NotBeNull();
            result.Should().BeOfType<WeatherData>();
            result!.Location.Should().Be("Amman");
            result.Temperature.Should().Be(20);
            result.Humidity.Should().Be(60);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid json")]
        public void Parse_ShouldReturnNull_WhenJsonIsInvalidOrEmpty(string input)
        {
            var result = _parser.Parse(input);
            result.Should().BeNull();
        }
    }
}
