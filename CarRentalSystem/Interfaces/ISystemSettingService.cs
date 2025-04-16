using CarRentalSystem.Data;
using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface ISystemSettingService
    {
        Task AddOrUpdateAsync(SystemSettingModel model);
        Task<IEnumerable<SystemSettingModel>> GetAllAsync();
        Task<SystemSettingModel?> GetByKeyAsync(string key);
    }
}