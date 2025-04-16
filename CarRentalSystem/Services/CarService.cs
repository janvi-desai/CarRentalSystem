using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repo;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CarModel>> GetAllAsync()
        {
            var cars = await _repo.GetAllAsync();
            return _mapper.Map<List<CarModel>>(cars);
        }

        public async Task<CarModel?> GetByIdAsync(int id)
        {
            var car = await _repo.GetByIdAsync(id);
            return _mapper.Map<CarModel>(car);
        }

        public async Task AddAsync(CarModel model)
        {
            if (string.IsNullOrEmpty(model.Model) || string.IsNullOrEmpty(model.Brand))
            {
                throw new ArgumentException("Model and Brand are required.");
            }

            var car = _mapper.Map<Car>(model);
            await _repo.AddAsync(car);
        }

        public async Task UpdateAsync(CarModel model)
        {
            var car = await _repo.GetByIdAsync(model.Id);
            if (car == null) throw new Exception("Car not found.");

            car.Transmission = model.Transmission;
            car.PricePerDay = model.PricePerDay;
            car.Year = model.Year;
            car.Brand = model.Brand;
            car.Description = model.Description;
            car.FuelType = model.FuelType;
            car.ImageUrl = model.ImageUrl;
            car.IsAvailable = model.IsAvailable;
            await _repo.UpdateAsync(car);
        }


        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<List<CarModel>> GetAvailableCarsAsync()
        {
            var availableCars = await _repo.GetAvailableCarsAsync();

            return _mapper.Map<List<CarModel>>(availableCars);
        }

        public async Task MarkAsRentedAsync(int id)
        {
            var car = await _repo.GetByIdAsync(id);
            if (car != null && car.IsAvailable)
            {
                car.IsAvailable = false;
                await _repo.UpdateAsync(car);
            }
        }
    }

}
