using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Data
{
    public class Car
    {
        public int Id { get; set; }
        [Required] public string Brand { get; set; } = string.Empty;
        [Required] public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<CarImage> Images { get; set; } = new();
    }

}
