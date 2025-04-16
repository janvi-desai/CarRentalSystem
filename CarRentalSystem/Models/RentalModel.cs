using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class RentalModel
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime RentDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public string PickupLocation { get; set; } = string.Empty;

        [Required]
        public string DropLocation { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }
    }
}
