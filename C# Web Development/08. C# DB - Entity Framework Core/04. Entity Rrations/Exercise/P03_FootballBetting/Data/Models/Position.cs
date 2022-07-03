using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        // --- Properties ---
        [Key]
        [Column("PositionId")]
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty("Position")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
