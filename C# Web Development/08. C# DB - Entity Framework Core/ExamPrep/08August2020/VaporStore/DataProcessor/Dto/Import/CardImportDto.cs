using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportDto
    {
        private const string numberRegex = @"^\d{4} \d{4} \d{4} \d{4}$";
        private const string cvcRegex = @"^\d{3}$";

        [Required]
        [RegularExpression(numberRegex)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(cvcRegex)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }
    }
}
