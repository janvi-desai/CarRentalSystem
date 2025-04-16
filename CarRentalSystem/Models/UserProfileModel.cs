using CarRentalSystem.Data;

namespace CarRentalSystem.Models
{
    public class UserProfileModel
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Rental> Rentals { get; set; } = new();
        public List<Payment> Payments { get; set; } = new();
    }

}
