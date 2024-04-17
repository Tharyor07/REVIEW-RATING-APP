using Microsoft.AspNetCore.Identity;

namespace repository_pattern.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
