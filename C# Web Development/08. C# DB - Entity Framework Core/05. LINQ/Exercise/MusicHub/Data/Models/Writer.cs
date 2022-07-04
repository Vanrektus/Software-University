using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public partial class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        // --- Properties ---
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Pseudonym { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Song.Writer))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
