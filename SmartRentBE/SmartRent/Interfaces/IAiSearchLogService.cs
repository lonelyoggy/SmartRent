using SmartRent.Models;

namespace SmartRent.Interfaces
{
    public interface IAiSearchLogService
    {
        Task<IEnumerable<AiSearchLog>> GetAllAsync();
        Task<AiSearchLog?> GetByIdAsync(int id);
        Task<AiSearchLog> CreateAsync(AiSearchLog log);
        Task<AiSearchLog?> UpdateAsync(int id, AiSearchLog log);
        Task<bool> DeleteAsync(int id);
    }
}
