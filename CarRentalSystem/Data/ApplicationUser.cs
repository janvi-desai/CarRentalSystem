using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
