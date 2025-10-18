using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImageController : ControllerBase
    {
        private readonly IRoomImageService _roomImageService;

        public RoomImageController(IRoomImageService roomImageService)
        {
            _roomImageService = roomImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roomImages = await _roomImageService.GetAllAsync();
            return Ok(roomImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roomImage = await _roomImageService.GetByIdAsync(id);
            return roomImage == null ? NotFound() : Ok(roomImage);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomImage image)
        {
            var created = await _roomImageService.CreateAsync(image);
            return CreatedAtAction(nameof(GetById), new { id = created.ImageId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomImage image)
        {
            var updated = await _roomImageService.UpdateAsync(id, image);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _roomImageService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
