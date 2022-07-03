using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public partial class Resource
    {
        [Key]
        [Column("ResourceId")]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        [Column("CourseId")]
        public int CourseId { get; set; }



        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Models.Course.Resources))]
        public virtual Course Course { get; set; }
    }
}
