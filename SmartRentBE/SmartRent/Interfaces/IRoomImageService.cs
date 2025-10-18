using SmartRent.Models;

namespace SmartRent.Interfaces
{
    public interface IRoomImageService
    {
        Task<IEnumerable<RoomImage>> GetAllAsync();
        Task<RoomImage?> GetByIdAsync(int id);
        Task<RoomImage> CreateAsync(RoomImage roomImage);
        Task<RoomImage?> UpdateAsync(int id, RoomImage roomImage);
        Task<bool> DeleteAsync(int id);
    }
}
