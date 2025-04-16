using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        // Optional role selection during registration
        public string Role { get; set; } = "User"; // Default to "User"
    }

}
