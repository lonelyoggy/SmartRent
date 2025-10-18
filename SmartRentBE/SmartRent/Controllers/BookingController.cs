using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            var created = await _bookingService.CreateAsync(booking);
            return CreatedAtAction(nameof(GetById), new { id = created.BookingId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Booking booking)
        {
            var updated = await _bookingService.UpdateAsync(id, booking);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookingService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
