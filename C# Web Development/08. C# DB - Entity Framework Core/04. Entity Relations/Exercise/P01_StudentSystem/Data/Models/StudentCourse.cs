using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public partial class StudentCourse
    {
        [Key]
        [Column("StudentId")]
        public int StudentId { get; set; }

        [Key]
        [Column("CourseId")]
        public int CourseId { get; set; }



        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Models.Student.CourseEnrollments))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Models.Course.StudentsEnrolled))]
        public virtual Course Course { get; set; }
    }
}
