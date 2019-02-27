using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "session")]
    public class Session
    {
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }
}
