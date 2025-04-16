using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<List<PaymentModel>>(payments);
        }

        public async Task<PaymentModel?> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentModel>(payment);
        }

        public async Task AddAsync(PaymentModel model)
        {
            var payment = _mapper.Map<Payment>(model);
            await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdateAsync(PaymentModel model)
        {
            var payment = _mapper.Map<Payment>(model);
            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
