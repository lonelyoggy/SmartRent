using SmartRent.Models;

namespace SmartRent.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> UpdateAsync(int id, Payment payment);
        Task<bool> DeleteAsync(int id);
    }
}
