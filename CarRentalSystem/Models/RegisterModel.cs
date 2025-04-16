using System.ComponentModel;
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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$",
            ErrorMessage = "Password must be at least 6 characters long and include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }

        // Optional role selection during registration
        public string Role { get; set; } = "User"; // Default to "User"
    }

}
