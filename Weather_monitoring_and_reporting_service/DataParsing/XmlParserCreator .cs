namespace weatherProj1.DataParsing
{
    public class XmlParserCreator : ParserCreator
    {
        public override IWeatherDataParser CreateParser()
        {
            return new XmlWeatherParser();
        }
    }
}
