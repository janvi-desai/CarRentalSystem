using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(1, double.MaxValue)]
        public decimal PricePerDay { get; set; }

        public string FuelType { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
