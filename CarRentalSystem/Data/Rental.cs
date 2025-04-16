using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Data
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        // Change from int to string because IdentityUser's Id is string (GUID)
        public string UserId { get; set; } = string.Empty;

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Active, Completed, Cancelled
        public decimal TotalAmount { get; set; }

        public string PickupLocation { get; set; } = string.Empty;
        public string DropLocation { get; set; } = string.Empty;

        public Car Car { get; set; } = null!;

        // Replace custom User with IdentityUser
        public IdentityUser User { get; set; } = null!;
    }
}
