using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_proj.Data;
using API_proj.Models;
using System.Security.Claims;

namespace API_proj.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public async Task<ActionResult<User>> GetMyProfile()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int userId)) return Unauthorized();

            var user = await _context.Participants.FindAsync(userId);
            if (user == null) return NotFound();

            user.PasswordHash = string.Empty; // Never expose password hash
            return user;
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] User updatedUser)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int userId)) return Unauthorized();

            var user = await _context.Participants.FindAsync(userId);
            if (user == null) return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Phone = updatedUser.Phone;
            user.DateOfBirth = updatedUser.DateOfBirth;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}