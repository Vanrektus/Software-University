using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Category
    {
        public Category()
        {
            this.CategoryBooks = new HashSet<BookCategory>();
        }

        // --- Properties ---
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(BookCategory.Category))]
        public virtual ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
