namespace CarRentalSystem.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Card, UPI, Cash, etc.
        public string Status { get; set; } = "Completed";
        public DateTime PaymentDate { get; set; }

        public Rental Rental { get; set; } = null!;
    }
}
