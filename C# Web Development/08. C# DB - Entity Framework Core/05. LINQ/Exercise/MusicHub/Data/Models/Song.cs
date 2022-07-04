using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public partial class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        // --- Properties ---
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Column("AlbumId")]
        public int? AlbumId { get; set; }

        [Column("WriterId")]
        public int WriterId { get; set; }

        [Required]
        public decimal Price { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; }


        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(SongPerformer.Song))]
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
