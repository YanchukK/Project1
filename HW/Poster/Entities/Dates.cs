using System.Collections.Generic;
using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "dates")]
    public class Dates
    {
        [XmlElement(ElementName = "date")]
        public List<Date> Date { get; set; }
    }
}
