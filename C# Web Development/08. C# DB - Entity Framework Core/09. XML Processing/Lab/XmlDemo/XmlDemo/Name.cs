using System.Xml.Serialization;

namespace XmlDemo
{
    public class Name
    {
        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }
    }
}
