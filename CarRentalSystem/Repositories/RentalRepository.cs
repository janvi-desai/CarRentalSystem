
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rental>> GetAllRentalsAsync()
        {
            return await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            return await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Rental>> GetRentalsByUserIdAsync(string userId)
        {
            return await _context.Rentals
                .Include(r => r.Car)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}
