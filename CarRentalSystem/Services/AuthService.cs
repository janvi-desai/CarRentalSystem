using CarRentalSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRentalSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterAsync(string email, string password, string role)
        {
            return await _authRepository.RegisterAsync(email, password, role);
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _authRepository.LoginAsync(email, password);
        }

        public async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var roles = await GetUserRolesAsync(user); // Now you can call this method
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await _authRepository.GetUserByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRolesAsync(IdentityUser user)
        {
            return await _authRepository.GetUserRolesAsync(user); // Call to AuthRepository to get user roles
        }
    }
}
