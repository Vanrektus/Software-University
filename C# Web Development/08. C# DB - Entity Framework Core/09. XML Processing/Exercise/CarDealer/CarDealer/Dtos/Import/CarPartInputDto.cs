using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("partId")]
    public class CarPartInputDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }


    }
}
