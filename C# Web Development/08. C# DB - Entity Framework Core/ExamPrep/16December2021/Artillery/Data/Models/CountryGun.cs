using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        // --- Properties ---
        [Key]
        public int CountryId { get; set; }

        [Key]
        public int GunId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        [ForeignKey(nameof(GunId))]
        public Gun Gun { get; set; }
    }
}
