using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemSettingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SystemSetting?> GetByKeyAsync(string key)
        {
            return await _context.SystemSettings.FirstOrDefaultAsync(s => s.Key == key);
        }

        public async Task<List<SystemSetting>> GetAllAsync()
        {
            return await _context.SystemSettings.ToListAsync();
        }

        public async Task AddOrUpdateAsync(SystemSetting setting)
        {
            var existing = await _context.SystemSettings.FirstOrDefaultAsync(s => s.Key == setting.Key);
            if (existing != null)
            {
                existing.Value = setting.Value;
                _context.SystemSettings.Update(existing);
            }
            else
            {
                await _context.SystemSettings.AddAsync(setting);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string key)
        {
            var setting = await _context.SystemSettings.FirstOrDefaultAsync(s => s.Key == key);
            if (setting != null)
            {
                _context.SystemSettings.Remove(setting);
                await _context.SaveChangesAsync();
            }
        }
    }
}
