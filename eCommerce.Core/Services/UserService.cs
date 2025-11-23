using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthResponse?> Register(RegisterDTO registerRequest)
    {
        var user = _mapper.Map<ApplicationUser>(registerRequest);

        var exists = await _userRepository
            .FindUserByEmailAndPassword(registerRequest.Email, registerRequest.Password) != null;

        if (exists)
            return null;

        var response = await _userRepository.AddUser(user);

        return response is not null
            ? _mapper.Map<AuthResponse>(response) with { IsSuccess = true, Token = "token" }
            : null;
    }

    public async Task<AuthResponse?> Login(LoginDTO loginRequest)
    {
        var user = await _userRepository.FindUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        return user is not null 
            ?_mapper.Map<AuthResponse>(user) with { IsSuccess = true, Token = "token"}
            : null;
    }

    public string HashPassword(string password)
    {
        return string.Empty;
    }
}
