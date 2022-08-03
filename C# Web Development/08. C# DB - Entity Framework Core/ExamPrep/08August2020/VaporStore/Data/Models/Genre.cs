using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Games = new HashSet<Game>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Game.Genre))]
        public ICollection<Game> Games { get; set; }
    }
}
