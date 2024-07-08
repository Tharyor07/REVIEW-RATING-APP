using repository_pattern.DTO;
using repository_pattern.Model;

namespace repository_pattern.Services
{
    public interface IAuth 
    {
        Task<string> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<(bool, AuthResponse)> LoginUser(LoginUserDTO loginUserDTO,ApplicationUser user);
        Task<ApplicationUser> FindUserByUsername(string userName);
    }
}
