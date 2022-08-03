using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Purchases = new HashSet<Purchase>();
            this.GameTags = new HashSet<GameTag>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public int GenreId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(DeveloperId))]
        public Developer Developer { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Purchase.Game))]
        public ICollection<Purchase> Purchases { get; set; }

        [InverseProperty(nameof(GameTag.Game))]
        public ICollection<GameTag> GameTags { get; set; }
    }
}
