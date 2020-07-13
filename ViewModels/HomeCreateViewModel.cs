using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShowWatch.ViewModels
{
    public class HomeCreateViewModel
    {
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
        [Required]
        public int Price { get; set; }
        public IFormFile AvatarPath { get; set; }
        public int CategoryId{ get; set; }

    }
}
