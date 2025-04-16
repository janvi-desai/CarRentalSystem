using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface IRentalService
    {
        Task<List<RentalModel>> GetAllRentalsAsync();
        Task<RentalModel?> GetRentalByIdAsync(int id);
        Task<int> CreateRentalAsync(RentalModel model);
        Task<bool> UpdateRentalAsync(RentalModel model);
        Task<bool> DeleteRentalAsync(int id);
    }

}
