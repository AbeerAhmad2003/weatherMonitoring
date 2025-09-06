using FluentAssertions;
using weatherProj1.DataParsing;

namespace WeatherService
{
    public class ParserFactoryTests
    {
        [Theory]
        [InlineData("{\"Location\":\"Cairo\",\"Temperature\":25,\"Humidity\":50}")]
        public void CreateParser_ShouldReturnJsonParser_ForJsonInput(string json)
        {
            var creator = ParserFactory.CreateParser(json);

            Assert.IsType<JsonParserCreator>(creator);
            var parser = creator.CreateParser();
            Assert.IsType<JsonWeatherDataParser>(parser);
        }

        [Theory]
        [InlineData("<WeatherData><Location>Cairo</Location><Temperature>25</Temperature><Humidity>50</Humidity></WeatherData>")]
        public void CreateParser_ShouldReturnXmlParser_ForXmlInput(string xml)
        {
            var creator = ParserFactory.CreateParser(xml);

            Assert.IsType<XmlParserCreator>(creator);
            var parser = creator.CreateParser();
            Assert.IsType<XmlWeatherParser>(parser);
        }

        [Fact]
        public void CreateParser_ShouldThrow_ForUnsupportedInput()
        {
            string invalid = "Some random string";
            Action act = () => ParserFactory.CreateParser(invalid);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Unsupported format");
        }
    }
}
