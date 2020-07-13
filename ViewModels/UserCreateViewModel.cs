using System;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Cormfirm password not match")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }

        public string Address { get; set; }
        [Display(Name = "Role")]

        public string RoleId { get; set; }
    }
}
