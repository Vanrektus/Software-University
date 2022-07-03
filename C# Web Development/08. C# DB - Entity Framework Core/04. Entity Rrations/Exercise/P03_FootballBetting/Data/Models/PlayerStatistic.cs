using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class PlayerStatistic
    {
        // --- Properties ---
        [Key]
        [Column("GameId")]
        public int GameId { get; set; }

        [Key]
        [Column("PlayerId")]
        public int PlayerId { get; set; }

        [Required]
        public int ScoredGoals { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        public int MinutesPlayed { get; set; }


        // --- Foreign Keys ---
        [ForeignKey(nameof(GameId))]
        [InverseProperty(nameof(Models.Game.PlayerStatistics))]
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [InverseProperty(nameof(Models.Player.PlayerStatistics))]
        public virtual Player Player { get; set; }
    }
}
