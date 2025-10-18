using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly SmartRentContext _context;

        public ApartmentService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> GetByIdAsync(int id) 
        { 
            return await _context.Apartments.FindAsync(id);
        }

        public async Task<Apartment> CreateAsync(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task<Apartment> UpdateAsync(int id, Apartment apartment)
        {
            var existing = await _context.Apartments.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(apartment);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Apartments.FindAsync(id);
            if (existing == null) return false;

            _context.Apartments.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
