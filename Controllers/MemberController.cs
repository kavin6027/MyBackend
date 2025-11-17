using Microsoft.AspNetCore.Mvc;
using MyBackend.Models;
using MyBackend.Data;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly AppDbContext _context;
    public MembersController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Members.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var member = _context.Members.Find(id);
        if (member == null) return NotFound();
        return Ok(member);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Member member)
    {
        var existing = _context.Members.Find(id);
        if (existing == null) return NotFound();
        existing.Name = member.Name;
        existing.Mobile = member.Mobile;
        existing.Status = member.Status;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var member = _context.Members.Find(id);
        if (member == null) return NotFound();
        _context.Members.Remove(member);
        _context.SaveChanges();
        return NoContent();
    }
}
