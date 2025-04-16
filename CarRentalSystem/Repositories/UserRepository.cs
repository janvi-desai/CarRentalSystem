using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateUserNameAsync(string email, string newName)
        {
            var user = await GetUserByEmailAsync(email);
            if (user != null)
            {
                user.UserName = newName;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<List<Rental>> GetRentalsByUserEmailAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return new List<Rental>();

            return await _context.Rentals
                .Include(r => r.Car)
                .Where(r => r.UserId == user.Id)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsByUserEmailAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return new List<Payment>();

            var rentalIds = await _context.Rentals
                .Where(r => r.UserId == user.Id)
                .Select(r => r.Id)
                .ToListAsync();

            return await _context.Payments
                .Where(p => rentalIds.Contains(p.RentalId))
                .ToListAsync();
        }
    }

}
