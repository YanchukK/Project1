using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "movie")]
    public class Movie
    {
        [XmlElement(ElementName = "sessions")]
        public Sessions Sessions { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
