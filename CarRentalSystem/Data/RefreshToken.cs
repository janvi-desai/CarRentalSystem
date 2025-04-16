using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Data
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRevoked { get; set; } = false;

        public string UserId { get; set; } = string.Empty; // IdentityUser uses string Id
        public IdentityUser User { get; set; } = null!;
    }
}
