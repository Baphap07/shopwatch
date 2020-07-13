using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [MaxLength(20)]
        [Required]
        public string CategoryName{ get; set; }
        public ICollection<Product> products { get; set; }
    }
}
