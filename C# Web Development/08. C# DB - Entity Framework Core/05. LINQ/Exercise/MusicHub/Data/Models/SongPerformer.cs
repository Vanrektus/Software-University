using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public partial class SongPerformer
    {
        // --- Properties ---
        [Key]
        [Column("SongId")]
        public int SongId { get; set; }

        [Key]
        [Column("PerformerId")]
        public int PerformerId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(SongId))]
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(PerformerId))]
        public virtual Performer Performer { get; set; }
    }
}
