using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions<MusicHubDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MusicHub;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new { sp.SongId, sp.PerformerId });
            });
        }
    }
}
