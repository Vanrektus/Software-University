﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORMCodeFirstDemo.Models
{
    public class Category
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }

        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
