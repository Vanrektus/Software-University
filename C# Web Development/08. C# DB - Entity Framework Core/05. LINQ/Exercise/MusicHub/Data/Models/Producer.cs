using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public partial class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        // --- Properties ---
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Album.Producer))]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
