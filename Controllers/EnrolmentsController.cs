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
    public class EnrolmentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EnrolmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Participant")]
        public async Task<ActionResult<Enrolment>> CreateEnrolment([FromBody] Enrolment enrolment)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int participantId)) return Unauthorized();

            enrolment.ParticipantId = participantId;
            enrolment.EnrolmentDate = DateTime.Now;

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return Ok(enrolment);
        }

        [HttpGet("mine")]
        [Authorize(Roles = "Participant")]
        public async Task<ActionResult<IEnumerable<Enrolment>>> GetMyEnrolments()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int participantId)) return Unauthorized();

            return await _context.Enrolments
                .Include(e => e.Category)
                .ThenInclude(c => c!.Event)
                .Where(e => e.ParticipantId == participantId)
                .ToListAsync();
        }

        [HttpGet("event/{eventId}")]
        [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<IEnumerable<Enrolment>>> GetEventEnrolments(int eventId)
        {
            var ev = await _context.Events.FindAsync(eventId);
            if (ev == null) return NotFound();

            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdStr, out int organiserId) && ev.OrganiserId != organiserId)
            {
                return Forbid();
            }

            return await _context.Enrolments
                .Include(e => e.Category)
                .Where(e => e.Category!.EventId == eventId)
                .ToListAsync();
        }
    }
}