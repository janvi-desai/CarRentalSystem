namespace CarRentalSystem.Models
{
    public class AdminDashboardModel
    {
        public int TotalUsers { get; set; }
        public int TotalCars { get; set; }
        public int ActiveRentals { get; set; }
        public int CompletedPayments { get; set; }
    }

}
