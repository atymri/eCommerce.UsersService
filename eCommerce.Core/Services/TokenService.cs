using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace eCommerce.Core.Services
{
    internal class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public TokenService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public AuthResponse GenerateToken(AuthResponse user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var expirationDate = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));

            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new (JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.Name, user.Email)
            };

            var signInCredits = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenGenerator = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: signInCredits);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenGenerator);

            var authResponse = _mapper.Map<AuthResponse>(user) with { Token = token };

            return authResponse;
        }
    }
}
