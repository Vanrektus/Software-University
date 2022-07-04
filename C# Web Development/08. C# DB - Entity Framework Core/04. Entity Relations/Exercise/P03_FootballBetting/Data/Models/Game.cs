using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        // --- Properties ---
        [Key]
        [Column("GameId")]
        public int GameId { get; set; }

        [Column("HomeTeamId")]
        public int HomeTeamId { get; set; }

        [Column("AwayTeamId")]
        public int AwayTeamId { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public double HomeTeamBetRate { get; set; }

        [Required]
        public double AwayTeamBetRate { get; set; }

        [Required]
        public double DrawBetRate { get; set; }

        [Required]
        public double Result { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(HomeTeamId))]
        public virtual Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        public virtual Team AwayTeam { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(PlayerStatistic.Game))]
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        [InverseProperty(nameof(Bet.Game))]
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
