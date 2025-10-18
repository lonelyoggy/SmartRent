using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogPosts = await _blogPostService.GetAllAsync();
            return Ok(blogPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogPost = await _blogPostService.GetByIdAsync(id);
            if (blogPost == null) return NotFound();
            return Ok(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            var created = await _blogPostService.CreateAsync(blogPost);
            return CreatedAtAction(nameof(GetById), new { id = created.PostId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogPost blogPost)
        {
            var updated = await _blogPostService.UpdateAsync(id, blogPost);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _blogPostService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
