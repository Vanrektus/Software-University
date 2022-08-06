using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamImportDto
    {
        private const string nameRegex = @"[A-Za-z\d\.\-\s]{3,40}";

        // --- Properties ---
        [Required]
        //[MinLength(3)]
        //[MaxLength(40)]
        [RegularExpression(nameRegex)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }



        // --- Collections ---
        public int[] Footballers { get; set; }
    }
}
