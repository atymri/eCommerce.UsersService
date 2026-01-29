using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthResponse?> Login(LoginDTO loginRequest);
    Task<AuthResponse?> Register(RegisterDTO registerRequest);
    Task<UserResponse?> FindUserByID(Guid userId);
}

