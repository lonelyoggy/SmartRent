using Microsoft.AspNetCore.Mvc;
using SmartRent.Models;
using SmartRent.Interfaces;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var created = await _commentService.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = created.CommentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comment comment)
        {
            var updated = await _commentService.UpdateAsync(id, comment);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _commentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
