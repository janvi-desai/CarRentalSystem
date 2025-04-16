using CarRentalSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDashboardModel> GetDashboardDataAsync();
        Task<List<IdentityUser>> GetAllUsersAsync();
        Task DeleteUserAsync(string userId);
    }

}
