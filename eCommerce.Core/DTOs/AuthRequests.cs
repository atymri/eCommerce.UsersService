using eCommerce.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Core.DTOs;

public record LoginDTO(
    string? Email,
    string? Password)
{
    public LoginDTO() : this(default, default)
    {
        
    }
};

public record RegisterDTO(
    string? Email,
    string? Password,
    string? PersonName,
    GenderOptions? Gender)
{
    public RegisterDTO() : this(default, default, default, default)
    {
        
    }
};

