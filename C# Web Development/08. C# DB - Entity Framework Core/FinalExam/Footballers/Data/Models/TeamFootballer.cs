using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        // --- Properties ---
        [Key]
        public int TeamId { get; set; }

        [Key]
        public int FootballerId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public Footballer Footballer { get; set; }
    }
}
