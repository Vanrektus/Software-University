using Microsoft.EntityFrameworkCore;

namespace ORMCodeFirstDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CodeFirstDemo2022;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
        }

        public DbSet<News> News { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
