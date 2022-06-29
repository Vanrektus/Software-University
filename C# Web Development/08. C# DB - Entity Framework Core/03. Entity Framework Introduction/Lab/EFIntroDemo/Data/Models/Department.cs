using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFIntroDemo.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            DeletedEmployees = new HashSet<DeletedEmployee>();
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("ManagerID")]
        public int ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Employee.Departments))]
        public virtual Employee Manager { get; set; }
        [InverseProperty(nameof(DeletedEmployee.Department))]
        public virtual ICollection<DeletedEmployee> DeletedEmployees { get; set; }
        [InverseProperty(nameof(Employee.Department))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
