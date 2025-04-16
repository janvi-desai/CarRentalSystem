using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user, IList<string> roles);
    }
}
