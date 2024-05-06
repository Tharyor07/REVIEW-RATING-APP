using Microsoft.AspNetCore.Identity;
using repository_pattern.DTO;
using repository_pattern.Enum;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public class AuthService : IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;   
        }

        public async Task<string> LoginUser(LoginUserDTO loginUserDTO, ApplicationUser user)
        {
            // check user with password valid
            var IsPassword = await _userManager.CheckPasswordAsync(user, loginUserDTO.Password);
            if (IsPassword)
            {
                // generate token
                return "Successful";
            }

            return "Invalid password";
        }
        public async Task<ApplicationUser> FindUserByUsername(string userName) => await _userManager.FindByNameAsync(userName);
        public async Task<string> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            ApplicationUser user = new ApplicationUser()
            { Email = registerUserDTO.Email,
                FirstName = registerUserDTO.FirstName,
                LastName = registerUserDTO.LastName,
                EmailConfirmed = true,
            UserName = registerUserDTO.Email};

            // create user
            var createResult = await _userManager.CreateAsync(user,registerUserDTO.Password);
            if (createResult.Succeeded)
            {
                if (registerUserDTO.IsStudent)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(RoleName.Student.ToString());
                    if(!roleExist)
                    {
                        // add role to application
                        IdentityRole role = new IdentityRole(RoleName.Student.ToString());
                        var RoleResult = await _roleManager.CreateAsync(role);
                        if (!RoleResult.Succeeded)
                        {
                            return RoleResult.Errors.First().Description;
                        }
                    }
                    // add user to role
                    var AddStudentToRole = await _userManager.AddToRoleAsync(user,RoleName.Student.ToString());
                    if (AddStudentToRole.Succeeded)
                    {
                        return "Successful";
                    }
                    else
                    {
                        return AddStudentToRole.Errors.First().Description;
                    }
                }
                else
                {
                    var roleExist = await _roleManager.RoleExistsAsync(RoleName.Teacher.ToString());
                    if (!roleExist)
                    {
                        // add role to application
                        IdentityRole role = new IdentityRole(RoleName.Teacher.ToString());
                        var RoleResult = await _roleManager.CreateAsync(role);
                        if (!RoleResult.Succeeded)
                        {
                            return RoleResult.Errors.First().Description;
                        }
                    }
                    // add user to role
                    var AddTeacherToRole = await _userManager.AddToRoleAsync(user, RoleName.Teacher.ToString());
                    if (AddTeacherToRole.Succeeded)
                    {
                        return "Successful";
                    }
                    else
                    {
                        return AddTeacherToRole.Errors.First().Description;
                    }
                }
            }
            return  createResult.Errors.First().Description;
        }
    }
}
