using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        // --- Properties ---
        [Key]
        [Column("AuthorId")]
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
