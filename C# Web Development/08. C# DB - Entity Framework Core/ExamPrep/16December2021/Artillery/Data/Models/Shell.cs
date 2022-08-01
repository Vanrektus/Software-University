using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1680)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Gun.Shell))]
        public ICollection<Gun> Guns { get; set; }
    }
}
