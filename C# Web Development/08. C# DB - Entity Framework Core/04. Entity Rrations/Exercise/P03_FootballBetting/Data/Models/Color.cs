using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        // --- Properties ---
        [Key]
        [Column("ColorId")]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty("Team")]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
