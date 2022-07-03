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

        [Column("PlayerId")]
        public int TeamId { get; set; }

        [Column("PlayerId")]
        public int PositionId { get; set; }

        [Required]
        public bool IsInjured { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(TeamId))]
        [InverseProperty(nameof(Models.Team.Players))]
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(PositionId))]
        [InverseProperty(nameof(Models.Position.Players))]
        public virtual Position Position { get; set; }



        // --- Collections ---
        [InverseProperty("Player")]
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
