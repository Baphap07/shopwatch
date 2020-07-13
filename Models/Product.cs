using System;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Radius { get; set; }
        [Required]
        public string Thickness { get; set; }
        [Required]
        public string Cord { get; set; }
        [Required]
        public string Glasses { get; set; }
        [Required]
        public string water_proof { get; set; }
        [Required]
        public string Guarantee { get; set; }
       
        public string Avatar { get; set; }
        [Required]
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }




    }
}
