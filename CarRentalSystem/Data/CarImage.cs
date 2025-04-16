namespace CarRentalSystem.Data
{
    public class CarImage
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Car Car { get; set; } = null!;
    }
}
