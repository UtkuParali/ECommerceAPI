using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    internal class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string?> AuthenticateUserAsync(UserLoginDto loginDto)
        {
            if (loginDto.Username == "admin" && loginDto.Password == "Pa$$w0rd")
            {
                var jwtKey = _configuration["Jwt:Key"]!;
                var jwtIssuer = _configuration["Jwt:Issuer"]!;
                var jwtAudience = _configuration["Jwt:Audience"]!;

                var expiresInMinutes = 30;


                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginDto.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtIssuer,
                    audience: jwtAudience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expiresInMinutes),
                    signingCredentials: credentials);
                
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }
    }
}
