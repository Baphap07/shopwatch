using System;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
       public string RoleName { get; set; }
    }
}
