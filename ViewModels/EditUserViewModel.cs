using System;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.ViewModels
{
    
        public class EditUserViewModel
        {
            public string UserId { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            public string City { get; set; }

            public string Address { get; set; }

            public string RoleId { get; set; }
        }
    
}
