using P01_StudentSystem.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public partial class Homework
    {
        [Key]
        [Column("HomeworkId")]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Column("StudentId")]
        public int StudentId { get; set; }

        [Column("CourseId")]
        public int CourseId { get; set; }



        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Models.Student.HomeworkSubmissions))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Models.Course.HomeworkSubmissions))]
        public virtual Course Course { get; set; }


    }
}
