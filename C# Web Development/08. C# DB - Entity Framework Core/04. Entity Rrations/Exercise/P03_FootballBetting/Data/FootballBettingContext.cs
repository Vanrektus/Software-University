﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public partial class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBookmakerSystem;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(t => t.PrimaryKitColor)
                       .WithMany(pkc => pkc.PrimaryKitTeams)
                       .HasForeignKey(t => t.PrimaryKitColorId)
                       .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                       .WithMany(skc => skc.SecondaryKitTeams)
                       .HasForeignKey(t => t.SecondaryKitColorId)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(g => g.AwayTeam)
                   .WithMany(at => at.AwayGames)
                   .HasForeignKey(g => g.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.HomeTeam)
                   .WithMany(ht => ht.HomeGames)
                   .HasForeignKey(g => g.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
