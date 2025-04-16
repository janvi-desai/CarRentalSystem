using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _repository;
        private readonly IMapper _mapper;

        public SystemSettingService(ISystemSettingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddOrUpdateAsync(SystemSettingModel model)
        {
            var entity = _mapper.Map<SystemSetting>(model);
            await _repository.AddOrUpdateAsync(entity);
        }

        public async Task<IEnumerable<SystemSettingModel>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<SystemSettingModel>>(list);
        }

        public async Task<SystemSettingModel?> GetByKeyAsync(string key)
        {
            var setting = await _repository.GetByKeyAsync(key);
            return setting != null ? _mapper.Map<SystemSettingModel>(setting) : null;
        }
    }
}
