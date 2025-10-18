using SmartRent.Models;

namespace SmartRent.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task<Room> CreateAsync(Room room);
        Task<Room?> UpdateAsync(int id, Room room);
        Task<bool> DeleteAsync(int id);
    }
}
