using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentsEnrolled = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        [Column("CourseId")]
        public int CourseId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }



        [InverseProperty("Course")]
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Resource> Resources { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
