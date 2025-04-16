using CarRentalSystem.Data;

namespace CarRentalSystem.Interfaces
{
    // Payment Repository Interface
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int id);
    }

}
