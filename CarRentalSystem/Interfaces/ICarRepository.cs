// Interfaces/ICarRepository.cs
using CarRentalSystem.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(int id);
        Task<List<Car>> GetAvailableCarsAsync();
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
        Task MarkAsRentedAsync(int carId);
    }
}
