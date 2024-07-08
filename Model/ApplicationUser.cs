using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace repository_pattern.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
