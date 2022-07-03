using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        // --- Properties ---
        [Key]
        [Column("CountryId")]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty("Country")]
        public virtual ICollection<Town> Towns { get; set; }
    }
}
