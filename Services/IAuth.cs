using repository_pattern.DTO;

namespace repository_pattern.Services
{
    public interface IAuth
    {
        Task<string> RegisterUser(RegisterUserDTO registerUserDTO);
    }
}
