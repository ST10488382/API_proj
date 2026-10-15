using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_proj.Data;
using API_proj.Models;
using System.Security.Claims;

namespace API_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ResultsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<Result>> CreateResult([FromBody] Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet("mine")]
        [Authorize(Roles = "Participant")]
        public async Task<ActionResult<IEnumerable<Result>>> GetMyResults()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int participantId)) return Unauthorized();

            return await _context.Results
                .Include(r => r.Enrolment)
                .ThenInclude(e => e!.Category)
                .ThenInclude(c => c!.Event)
                .Where(r => r.Enrolment!.ParticipantId == participantId)
                .ToListAsync();
        }

        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<Result>>> GetEventResults(int eventId)
        {
            return await _context.Results
                .Include(r => r.Enrolment)
                .ThenInclude(e => e!.Category)
                .Where(r => r.Enrolment!.Category!.EventId == eventId)
                .ToListAsync();
        }
    }
}
