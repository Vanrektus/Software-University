using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseImportDto
    {
        private const string productKeyRegex = @"^\w{4}\-\w{4}\-\w{4}$";
        private const string cardNumberRegex = @"^\d{4} \d{4} \d{4} \d{4}$";

        [Required]
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [Required]
        [XmlElement("Type")]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(productKeyRegex)]
        [XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        [RegularExpression(cardNumberRegex)]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
