using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1.DataParsing
{
    public class JsonParserCreator : ParserCreator
    {
        public override IWeatherDataParser CreateParser()
        {
            return new JsonWeatherDataParser();
        }
    }
}
