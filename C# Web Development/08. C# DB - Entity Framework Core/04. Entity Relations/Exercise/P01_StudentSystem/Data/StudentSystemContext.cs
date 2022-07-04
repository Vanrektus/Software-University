using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P01_StudentSystem.Data.Models;
using System.Reflection.Emit;

namespace P01_StudentSystem.Data
{
    public partial class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name)
                .IsUnicode(true);

                entity.Property(s => s.PhoneNumber)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name)
                .IsUnicode(true);

                entity.Property(c => c.Description)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Name)
                .IsUnicode(true);

                entity.Property(r => r.Url)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content)
                .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });
            });
        }
    }
}
