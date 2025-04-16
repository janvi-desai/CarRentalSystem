using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using CarRentalSystem.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<AdminDashboardModel> GetDashboardDataAsync()
        {
            var dashboard = new AdminDashboardModel
            {
                TotalUsers = await _adminRepository.GetTotalUsersAsync(),
                TotalCars = await _adminRepository.GetTotalCarsAsync(),
                ActiveRentals = await _adminRepository.GetActiveRentalsAsync(),
                CompletedPayments = await _adminRepository.GetCompletedPaymentsAsync()
            };

            return dashboard;
        }

        public async Task<List<IdentityUser>> GetAllUsersAsync()
        {
            return await _adminRepository.GetAllUsersAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            await _adminRepository.DeleteUserAsync(userId);
        }
    }
}
