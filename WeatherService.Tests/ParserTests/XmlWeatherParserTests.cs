using FluentAssertions;
using weatherProj1;
using weatherProj1.DataParsing;

namespace WeatherService
{
    public class XmlWeatherParserTests
    {
        private readonly XmlWeatherParser _parser;
        public XmlWeatherParserTests()
        {
            _parser = new XmlWeatherParser();
        }
        [Fact]
        public void Parse_ShouldReturnWeatherData_WhenXmlIsValid()
        {
            string xml = @"<WeatherData>
                               <Location>Cairo</Location>
                               <Temperature>30</Temperature>
                               <Humidity>70</Humidity>
                           </WeatherData>";
            var result = _parser.Parse(xml);
            result.Should().NotBeNull();
            result.Should().BeOfType<WeatherData>();
            result!.Location.Should().Be("Cairo");
            result.Temperature.Should().Be(30);
            result.Humidity.Should().Be(70);

        }
        [Theory]
        [InlineData("<Invalid>NotWeatherData</Invalid>")]
        [InlineData("")]
        public void Parse_ShouldReturnNull_WhenXmlIsInvalidOrEmpty(string input)
        {

            var result = _parser.Parse(input);
            result.Should().BeNull();
        }
    }
}
