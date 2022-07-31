using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UserProductFinalOutputDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<UserSoldProductCountOutputDto> Users { get; set; }
    }

    [XmlType("User")]
    public class UserSoldProductCountOutputDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductCountOutputDto SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class SoldProductCountOutputDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ProductOutputDto> Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductOutputDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
