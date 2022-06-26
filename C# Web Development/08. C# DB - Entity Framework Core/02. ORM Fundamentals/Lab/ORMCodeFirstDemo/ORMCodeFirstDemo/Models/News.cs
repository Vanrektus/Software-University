﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORMCodeFirstDemo.Models
{
    public class News
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Title { get; set; }

        [MaxLength(300), Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
