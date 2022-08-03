using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            this.GameTags = new HashSet<GameTag>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(GameTag.Tag))]
        public ICollection<GameTag> GameTags { get; set; }
    }
}
