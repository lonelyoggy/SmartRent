using Microsoft.EntityFrameworkCore;
using SmartRent.Interfaces;
using SmartRent.Models;
using SmartRent.Data;

namespace SmartRent.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly SmartRentContext _context;

        public BlogPostService(SmartRentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        } 

        public async Task<BlogPost> CreateAsync(BlogPost blogPosts)
        {
            _context.BlogPosts.Add(blogPosts);
            await _context.SaveChangesAsync();
            return blogPosts;
        }

        public async Task<BlogPost> UpdateAsync(int id, BlogPost blogPost)
        {
            var existing = await _context.BlogPosts.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(blogPost);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.BlogPosts.FindAsync(id);
            if (existing == null) return false;

            _context.BlogPosts.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
