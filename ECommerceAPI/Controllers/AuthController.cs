using Asp.Versioning;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            _logger.LogInformation("Giriş denemesi: {Username}", loginDto.Username);
            var token = await _authService.AuthenticateUserAsync(loginDto);
            if (token == null)
            {
                _logger.LogWarning("Giriş başarısız, yanlış kullanıcı adı veya şifre: {Username}", loginDto.Username);
                return Unauthorized("Yanlış kullanıcı adı veya şifre.");
            }
            _logger.LogInformation("Giriş başarılı: {UserName}", loginDto.Username);
            return Ok(new { Token = token });
        }
    }
}
