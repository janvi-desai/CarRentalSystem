using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileModel> GetUserProfileAsync(string email);
        Task UpdateUserNameAsync(string email, string newName);
    }

}
