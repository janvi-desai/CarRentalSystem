using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<List<RentalModel>> GetAllRentalsAsync()
        {
            var rentals = await _rentalRepository.GetAllRentalsAsync();
            return _mapper.Map<List<RentalModel>>(rentals);
        }

        public async Task<RentalModel?> GetRentalByIdAsync(int id)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(id);
            return rental == null ? null : _mapper.Map<RentalModel>(rental);
        }

        public async Task<int> CreateRentalAsync(RentalModel model)
        {
            var rental = _mapper.Map<Rental>(model);
            await _rentalRepository.AddRentalAsync(rental);

            return rental.Id;
        }

        public async Task<bool> UpdateRentalAsync(RentalModel model)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(model.Id);
            if (rental == null) return false;

            _mapper.Map(model, rental);
            await _rentalRepository.UpdateRentalAsync(rental);

            return rental.Id > 0;
        }

        public async Task<bool> DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
            return true;
        }
    }
}
