using Microsoft.EntityFrameworkCore;
using SmartRent.Data;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Services
{
    public class CommentService : ICommentService
    {
        private readonly SmartRentContext _context;
        public CommentService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> UpdateAsync(int id, Comment comment)
        {
            var existing = await _context.Comments.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(comment);
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Comments.FindAsync(id);
            if (existing == null) return false;
            _context.Comments.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
