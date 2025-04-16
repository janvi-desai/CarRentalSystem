using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        [Required]
        public int RentalId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = "UPI";

        public string Status { get; set; } = "Completed";
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
