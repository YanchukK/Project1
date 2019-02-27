using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "date")]
    public class Date
    {
        [XmlElement(ElementName = "movies")]
        public Movies Movies { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
