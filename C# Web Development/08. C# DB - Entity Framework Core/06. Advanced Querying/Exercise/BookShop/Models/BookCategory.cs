using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class BookCategory
    {
        // --- Properties ---
        [Key]
        [Column("BookId")]
        public int BookId { get; set; }

        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
