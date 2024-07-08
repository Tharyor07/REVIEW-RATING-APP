using Microsoft.AspNetCore.Identity;
using repository_pattern.DTO;
using repository_pattern.Enum;
using repository_pattern.Model;
using System.ComponentModel;

namespace repository_pattern.Services
{
    public class AuthService : IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;   
            _configuration = configuration; 
        }

        public async Task<(bool,AuthResponse)> LoginUser(LoginUserDTO loginUserDTO, ApplicationUser user)
        {
            // check user with password valid
            var IsPassword = await _userManager.CheckPasswordAsync(user, loginUserDTO.Password);
            if (IsPassword)
            {
                // generate token
                var jwtToken = await _tokenGenerator.GenerateJwtToken(user.Id,user.PhoneNumber,user.UserName,user.Email,$"{user.FirstName} {user.LastName}");
                return (true,jwtToken);
            }
            return (false,null);
        }
        public async Task<ApplicationUser> FindUserByUsername(string userName) => await _userManager.FindByEmailAsync(userName);
        public async Task<string> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            string defaultPassword = _configuration["DefaultPassword:"];
            ApplicationUser user = new ApplicationUser()
            { Email = registerUserDTO.Email,
                FirstName = registerUserDTO.FirstName,
                LastName = registerUserDTO.LastName,
                Password =defaultPassword,
                EmailConfirmed = true,
             UserName = registerUserDTO.Email};

            // create user
            var createResult = await _userManager.CreateAsync(user, defaultPassword);
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

        //Write a function to generate token befor reset password
        //_userManager.GeneratePasswordResetTokenAsync(user);


        //public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        //{
        //    ApplicationUser user = await FindUserByUsername(resetPasswordDTO.Email);    
        //    //check if user is in above function

        //    var ddd = _userManager.ResetPasswordAsync(user,"token",resetPasswordDTO.NewPassword);
        //    if (ddd.IsCompleted)
        //    {
                
        //    }
        //}

  
    }
}
