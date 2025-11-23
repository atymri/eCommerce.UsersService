
namespace eCommerce.Core.DTOs;

public record AuthResponse(
    Guid? UserId,
    string? PersonName,
    string? Email,
    string? PhoneNumber,
    string? Gender,
    string? Token,
    bool IsSuccess
)
{
    // because this is an record and we need to map it in the service, it needs a parameterless constructor
    // so we add this constructor
    // btw this happens only for the destenation record in automapper
    public AuthResponse() : this(default, default, default, default, default, default, default)
    {
        
    }
}