using CarRentalSystem.Data;

namespace CarRentalSystem.Interfaces
{
    public interface ISystemSettingRepository
    {
        Task<SystemSetting?> GetByKeyAsync(string key);
        Task<List<SystemSetting>> GetAllAsync();
        Task AddOrUpdateAsync(SystemSetting setting);
        Task DeleteAsync(string key);
    }
}
