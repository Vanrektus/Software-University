using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        // --- Properties ---
        [Key]
        [Column("PlayerId")]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        [Column("TeamId")]
        public int TeamId { get; set; }

        [Column("PositionId")]
        public int PositionId { get; set; }

        [Required]
        public bool IsInjured { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(PlayerStatistic.Player))]
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
