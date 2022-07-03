using P03_FootballBetting.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Bet
    {
        // --- Properties ---
        [Key]
        [Column("BetId")]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("GameId")]
        public int GameId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Models.User.Bets))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty(nameof(Models.Game.Bets))]
        public virtual Game Game { get; set; }
    }
}
