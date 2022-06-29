using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFIntroDemo.Data.Models
{
    [Table("FirstNamesChangeLog")]
    public partial class FirstNamesChangeLog
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string OldFirstName { get; set; }
        [StringLength(50)]
        public string NewFirstName { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
