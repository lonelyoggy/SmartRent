using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Services
{
    public class RoomImageService : IRoomImageService
    {
        private readonly SmartRentContext _context;
        public RoomImageService(SmartRentContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoomImage>> GetAllAsync()
        {
            return await _context.RoomImages.ToListAsync();
        }
        public async Task<RoomImage> GetByIdAsync(int id)
        {
            return await _context.RoomImages.FindAsync(id);
        }
        public async Task<RoomImage> CreateAsync(RoomImage roomImage)
        {
            _context.RoomImages.Add(roomImage);
            await _context.SaveChangesAsync();
            return roomImage;
        }
        public async Task<RoomImage> UpdateAsync(int id, RoomImage roomImage)
        {
            var existing = await _context.RoomImages.FindAsync(id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(roomImage);
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.RoomImages.FindAsync(id);
            if (existing == null) return false;
            _context.RoomImages.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
