using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFIntroDemo.Data.Models
{
    [Table("Deleted_Employees")]
    public partial class DeletedEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string JobTitle { get; set; }
        public int? DepartmentId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("DeletedEmployees")]
        public virtual Department Department { get; set; }
    }
}
