using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiSearchLogService : ControllerBase
    {
        private readonly IAiSearchLogService _aiSearchLogService;

        public AiSearchLogService(IAiSearchLogService aiSearchLogService)
        {
            _aiSearchLogService = aiSearchLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _aiSearchLogService.GetAllAsync();
            return Ok(logs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _aiSearchLogService.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AiSearchLog log)
        {
            var created = await _aiSearchLogService.CreateAsync(log);
            return CreatedAtAction(nameof(GetById), new { id = created.LogId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AiSearchLog log)
        {
            var updated = await _aiSearchLogService.UpdateAsync(id, log);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _aiSearchLogService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
