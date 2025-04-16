using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalCarsAsync();
        Task<int> GetActiveRentalsAsync();
        Task<int> GetCompletedPaymentsAsync();
        Task<List<IdentityUser>> GetAllUsersAsync();
        Task DeleteUserAsync(string userId);
    }

}
