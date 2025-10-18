using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Services
{
    public class RoomService : IRoomService
    {
        private readonly SmartRentContext _context;
        public RoomService(SmartRentContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.RoomImages)
                .Include(r => r.Apartment)
                .ToListAsync();
        }
        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.RoomImages)
                .Include(r => r.Apartment)
                .FirstOrDefaultAsync(r => r.RoomId == id);
        }
        public async Task<Room> CreateAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<Room?> UpdateAsync(int id, Room room)
        {
            var existing = await _context.Rooms.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(room);
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Rooms.FindAsync(id);
            if (existing == null) return false;

            _context.Rooms.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
