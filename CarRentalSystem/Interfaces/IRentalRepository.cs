using CarRentalSystem.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarRentalSystem.Interfaces
{
    public interface IRentalRepository
    {
        Task<List<Rental>> GetAllRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
        Task<List<Rental>> GetRentalsByUserIdAsync(string userId);
    }
}