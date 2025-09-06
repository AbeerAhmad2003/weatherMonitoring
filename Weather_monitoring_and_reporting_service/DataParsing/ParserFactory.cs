namespace weatherProj1.DataParsing
{
    public static class ParserFactory
    {
        public static ParserCreator CreateParser(string data)
        {
            if (data.TrimStart().StartsWith("{"))
                return new JsonParserCreator();
            else if (data.TrimStart().StartsWith("<"))
                return new XmlParserCreator();
            else
                throw new InvalidOperationException("Unsupported format");
        }
    }
}
