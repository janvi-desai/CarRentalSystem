using CarRentalSystem.Data;
using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task UpdateUserNameAsync(string email, string newName);
        Task<List<Rental>> GetRentalsByUserEmailAsync(string email);
        Task<List<Payment>> GetPaymentsByUserEmailAsync(string email);
    }

}
