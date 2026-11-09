using API_proj.Data;
using API_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OrganisersController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public OrganisersController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrganiser([FromBody] Organiser organiser)
    {
        _context.Organisers.Add(organiser);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrganiser), new { id = organiser.OrganiserId }, organiser);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrganiser(int id)
    {
        var organiser = await _context.Organisers.FindAsync(id);
        if (organiser == null) return NotFound();
        return Ok(organiser);
    }
}