﻿using P03_FootballBetting.Data.Models.Enums;
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
        public Prediction Result { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(HomeTeamId))]
        [InverseProperty(nameof(Models.Team.HomeGames))]
        public virtual Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        [InverseProperty(nameof(Models.Team.AwayGames))]
        public virtual Team AwayTeam { get; set; }



        // --- Collections ---
        [InverseProperty("Game")]
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        [InverseProperty("Game")]
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
