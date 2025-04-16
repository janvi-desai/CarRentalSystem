using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface ICarService
    {
        Task<List<CarModel>> GetAllAsync();
        Task<CarModel?> GetByIdAsync(int id);
        Task AddAsync(CarModel carModel);
        Task UpdateAsync(CarModel carModel);
        Task DeleteAsync(int id);
        Task MarkAsRentedAsync(int id);
        Task<List<CarModel>> GetAvailableCarsAsync();
    }

}
