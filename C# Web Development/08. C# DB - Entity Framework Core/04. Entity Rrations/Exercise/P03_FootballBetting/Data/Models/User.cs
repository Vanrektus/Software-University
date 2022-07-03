using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public partial class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        // --- Properties ---
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }



        // --- Collections ---
        [InverseProperty("User")]
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
