using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        // --- Properties ---
        [Key]
        [Column("TeamId")]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(3), MinLength(3)]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Column("PrimaryKitColorId")]
        public int PrimaryKitColorId { get; set; }

        [Column("SecondaryKitColorId")]
        public int SecondaryKitColorId { get; set; }

        [Column("TownId")]
        public int TownId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(PrimaryKitColorId))]
        [InverseProperty(nameof(Models.Color.PrimaryKitTeams))]
        public virtual Color PrimaryKitColor { get; set; }

        [ForeignKey(nameof(SecondaryKitColorId))]
        [InverseProperty(nameof(Models.Color.SecondaryKitTeams))]
        public virtual Color SecondaryKitColor { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty(nameof(Models.Town.Teams))]
        public virtual Town Town { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; }

        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; }

        [InverseProperty(nameof(Player.Team))]
        public virtual ICollection<Player> Players { get; set; }
    }
}
