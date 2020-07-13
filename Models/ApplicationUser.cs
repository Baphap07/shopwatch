using System;
using Microsoft.AspNetCore.Identity;

namespace ShowWatch.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
        public string Address { get; set; }
    }
}
