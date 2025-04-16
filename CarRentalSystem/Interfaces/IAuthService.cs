using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(string email, string password, string role);
        Task<SignInResult> LoginAsync(string email, string password);
        Task<string> GenerateJwtToken(IdentityUser user);
        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task<IList<string>> GetUserRolesAsync(IdentityUser user); // Add this method
    }
}
