using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var apartments = await _apartmentService.GetAllAsync();
            return Ok(apartments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var apartment = await _apartmentService.GetByIdAsync(id);
            if (apartment == null) return NotFound();
            return Ok(apartment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            var created = await _apartmentService.CreateAsync(apartment);
            return CreatedAtAction(nameof(GetById), new { id = created.ApartmentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Apartment apartment)
        {
            var updated = await _apartmentService.UpdateAsync(id, apartment);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var deleted = await _apartmentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
