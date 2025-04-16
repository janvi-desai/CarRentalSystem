using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return await _userManager.Users.CountAsync();
        }

        public async Task<int> GetTotalCarsAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetActiveRentalsAsync()
        {
            return await _context.Rentals.CountAsync(r => r.Status != "Returned" && r.Status != "Cancelled");
        }

        public async Task<int> GetCompletedPaymentsAsync()
        {
            return await _context.Payments.CountAsync(p => p.Status == "Completed");
        }

        public async Task<List<IdentityUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }
}
