using eCommerce.Core.Enums;

namespace eCommerce.Core.DTOs;

public record LoginDTO(
    string? Email,
    string? Password);

public record RegisterDTO(
    string? Email,
    string? PhoneNumber,
    string? Password,
    string? ConfirmPassword,
    string? PersonName,
    GenderOptions? Gender);

