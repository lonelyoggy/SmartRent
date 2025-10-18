using SmartRent.Data;
using SmartRent.Models;
using Microsoft.EntityFrameworkCore;
using SmartRent.Interfaces;

namespace SmartRent.Services
{
    public class BookingService : IBookingService
    {
        private readonly SmartRentContext _context;

        public BookingService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<Booking> CreateAsync(Booking bookings)
        {
            _context.Bookings.Add(bookings);
            await _context.SaveChangesAsync();
            return bookings;
        }

        public async Task<Booking> UpdateAsync(int id, Booking booking)
        {
            var existing = await _context.Bookings.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(booking);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var existing = await _context.Bookings.FindAsync(id);
            if (existing == null) return false;

            _context.Bookings.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
