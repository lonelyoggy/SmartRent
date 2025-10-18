using SmartRent.Models;

namespace SmartRent.Interfaces
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
        Task<BlogPost> CreateAsync(BlogPost post);
        Task<BlogPost?> UpdateAsync(int id, BlogPost post);
        Task<bool> DeleteAsync(int id);
    }
}
