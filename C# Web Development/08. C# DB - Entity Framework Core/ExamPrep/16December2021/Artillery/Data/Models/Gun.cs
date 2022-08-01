using Artillery.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [MaxLength(1350000)]
        public int GunWeight { get; set; }

        [Required]
        [MaxLength(35)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [MaxLength(100000)]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [Required]
        public int ShellId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(ShellId))]
        public Shell Shell { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(CountryGun.Gun))]
        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
