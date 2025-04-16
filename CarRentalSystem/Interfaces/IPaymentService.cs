using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface IPaymentService
    {
        Task AddAsync(PaymentModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<PaymentModel>> GetAllAsync();
        Task<PaymentModel?> GetByIdAsync(int id);
        Task UpdateAsync(PaymentModel model);
    }
}