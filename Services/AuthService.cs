using Microsoft.AspNetCore.Identity;
using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public class AuthService : IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        public AuthService(RoleManager<ApplicationUser> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<string> RegisterUser(RegisterUserDTO registerUserDTO)
        {

        }
    }
}
