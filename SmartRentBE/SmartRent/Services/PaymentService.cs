using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;


namespace SmartRent.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly SmartRentContext _context;

        public PaymentService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdateAsync(int id, Payment payment)
        {
            var existing = await _context.Payments.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(payment);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Payments.FindAsync(id);
            if (existing == null) return false;

            _context.Payments.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
