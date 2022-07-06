using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Book
    {
        public Book()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }

        // --- Properties ---
        [Key]
        [Column("BookId")]
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        [Column("AuthorId")]
        public int AuthorId { get; set; }



        // --- Foreign Keys ---
        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }



        // --- Collections ---
        [InverseProperty(nameof(BookCategory.Book))]
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
