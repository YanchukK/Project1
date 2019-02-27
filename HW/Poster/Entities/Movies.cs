using System.Collections.Generic;
using System.Xml.Serialization;

namespace Poster
{
    [XmlRoot(ElementName = "movies")]
    public class Movies
    {
        [XmlElement(ElementName = "movie")]
        public List<Movie> Movie { get; set; }
    }
}
