using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        // --- Properties ---
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(10)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }

        public int TheatreId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(PlayId))]
        public Play Play { get; set; }

        [ForeignKey(nameof(TheatreId))]
        public Theatre Theatre { get; set; }
    }
}
