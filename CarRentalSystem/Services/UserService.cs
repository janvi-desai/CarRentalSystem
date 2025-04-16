using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProfileModel> GetUserProfileAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");

            var rentals = await _userRepository.GetRentalsByUserEmailAsync(email);
            var payments = await _userRepository.GetPaymentsByUserEmailAsync(email);

            return new UserProfileModel
            {
                Email = user.Email ?? string.Empty,
                Name = user.UserName ?? string.Empty,
                Rentals = rentals,
                Payments = payments
            };
        }

        public async Task UpdateUserNameAsync(string email, string newName)
        {
            await _userRepository.UpdateUserNameAsync(email, newName);
        }
    }

}
