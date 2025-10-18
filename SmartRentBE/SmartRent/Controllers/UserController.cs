using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRent.Interfaces;
using SmartRent.Models;

namespace SmartRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // ========== CRUD ==========
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var created = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var updated = await _userService.UpdateAsync(id, user);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        // ========== AUTH ==========
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user, string password)
        {
            var result = await _userService.RegisterAsync(user, password);
            if (result == null)
                return BadRequest("Email already exists.");
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _userService.LoginAsync(email, password);
            if (token == null)
                return Unauthorized("Invalid email or password.");
            return Ok(new { token });
        }
    }
}
