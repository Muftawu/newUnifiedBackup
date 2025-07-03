using DTOs;

namespace Shared.Application;

public interface IAuthService
{
    Task<LoginResponseDTOJWT> Login(LoginDTO loginDTO);

    Task<ResponseDTO> Register(RegisterDTO registerDTO);

    Task<ResponseDTO> GetUserById(Guid userId);

    Task<ResponseDTO> UpdateUser(Guid userId, UserDTO userdto);

    Task<ResponseDTO> CreateUserProfile(CreateUserProfileDTO createUserProfileDTO);
} 