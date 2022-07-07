using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public partial class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> BooksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BookShop;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(a => a.FirstName)
                .IsUnicode(true);

                entity.Property(a => a.LastName)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                .IsUnicode(true);

                entity.Property(b => b.Description)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name)
                .IsUnicode(true);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(bc => new { bc.BookId, bc.CategoryId });
            });
        }
    }
}
