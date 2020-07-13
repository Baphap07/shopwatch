using System;
using System.ComponentModel.DataAnnotations;

namespace ShowWatch.ViewModels
{
    public class EditRoleViewModel
    {
        public string  RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
