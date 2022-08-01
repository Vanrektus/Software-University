using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(10000000)]
        public int ArmySize { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(CountryGun.Country))]
        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
