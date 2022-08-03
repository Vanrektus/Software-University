using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        [MaxLength(3)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Purchase.Card))]
        public ICollection<Purchase> Purchases { get; set; }
    }
}
