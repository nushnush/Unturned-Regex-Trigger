using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegexTrigger
{
    public class Configuration : IRocketPluginConfiguration
    {
        [XmlArray("Regexes")]
        [XmlArrayItem(ElementName = "RegexItem")]
        public List<string> regexes;

        public void LoadDefaults()
        {
            regexes = new List<string>()
            {
                @"\bn[\s\W_]*[i1]+[\s\W_]*g+\w*", // nig
                @"\b(?:f|p[\s\W_]*h+)[\s\W_]*[a4]+[\s\W_]*g+\w*", // fag, phag
            };
        }
    }
}
