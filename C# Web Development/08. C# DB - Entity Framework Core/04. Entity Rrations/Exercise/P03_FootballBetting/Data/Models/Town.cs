using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        // --- Properties ---
        [Key]
        [Column("TownId")]
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("CountryId")]
        public int CountryId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Models.Country.Towns))]
        public virtual Country Country { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Team.Players))]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
