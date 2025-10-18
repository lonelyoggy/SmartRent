using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            return room == null ? NotFound() : Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            var created = await _roomService.CreateAsync(room);
            return CreatedAtAction(nameof(GetById), new { id = created.RoomId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Room room)
        {
            var updated = await _roomService.UpdateAsync(id, room);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _roomService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
