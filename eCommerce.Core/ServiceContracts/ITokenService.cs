using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceContracts
{
    public interface ITokenService
    {
        AuthResponse GenerateToken(AuthResponse user);
    }
}
