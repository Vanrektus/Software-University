using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public partial class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        // --- Properties ---
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        // ???
        [Required]
        public decimal Price { get; set; }

        [Column("ProducerId")]
        public int? ProducerId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(ProducerId))]
        public virtual Producer Producer { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Song.Album))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
