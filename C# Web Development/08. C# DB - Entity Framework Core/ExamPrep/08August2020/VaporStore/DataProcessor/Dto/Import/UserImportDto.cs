using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportDto
    {
        private const string fullNameRegex = @"^[A-Z][a-z]+\s[A-Z][a-z]+$";

        public UserImportDto()
        {
            this.Cards = new HashSet<CardImportDto>();
        }

        [Required]
        [RegularExpression(fullNameRegex)]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }



        public ICollection<CardImportDto> Cards { get; set; }
    }
}
