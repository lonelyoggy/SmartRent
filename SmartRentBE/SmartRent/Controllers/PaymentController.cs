using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            var created = await _paymentService.CreateAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = created.PaymentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Payment payment)
        {
            var updated = await _paymentService.UpdateAsync(id, payment);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _paymentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
