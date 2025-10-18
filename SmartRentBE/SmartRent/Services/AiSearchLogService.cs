using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Services
{
    public class AiSearchLogService : IAiSearchLogService
    {
        private readonly SmartRentContext _context;

        public AiSearchLogService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AiSearchLog>> GetAllAsync()
        {
            return await _context.AiSearchLogs.ToListAsync();
        }

        public async Task<AiSearchLog> GetByIdAsync(int id)
        {
            return await _context.AiSearchLogs.FindAsync(id);
        }

        public async Task<AiSearchLog> CreateAsync(AiSearchLog aiSearchLog)
        {
            _context.AiSearchLogs.Add(aiSearchLog);
            await _context.SaveChangesAsync();
            return aiSearchLog;
        }

        public async Task<AiSearchLog> UpdateAsync(int id, AiSearchLog aiSearchLog)
        {
            var existing = await _context.AiSearchLogs.FindAsync(id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(aiSearchLog);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.AiSearchLogs.FindAsync(id);
            if (existing == null) return false;
            _context.AiSearchLogs.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
