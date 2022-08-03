using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [MaxLength(14)]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public int GameId { get; set; }


        // --- Foreign Keys ---
        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}
