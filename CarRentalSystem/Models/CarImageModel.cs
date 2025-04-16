using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class CarImageModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
