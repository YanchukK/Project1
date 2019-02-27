using System.Collections.Generic;
using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "sessions")]
    public class Sessions
    {
        [XmlElement(ElementName = "session")]
        public List<Session> Session { get; set; }
    }
}
