using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherProj1.parserFactoryMethod
{
    public class XmlParserCreator : ParserCreator
    {
        public override IWeatherDataParser CreateParser()
        {
            return new XmlWeatherParser();
        }
    }
}
