using AmigoPet.Data.Context;
using AmigoPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmigoPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareRemindersController : ControllerBase
    {
        private readonly AmigoPetContext _context;

        public CareRemindersController(AmigoPetContext context)
        {
            _context = context;
        }

        // GET: api/careReminders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareReminder>>> GetReminders()
        {
            return await _context.CareReminders.ToListAsync();
        }

        // GET: api/careReminders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareReminder>> GetReminder(int id)
        {
            var reminder = await _context.CareReminders.FindAsync(id);

            if (reminder == null)
                return NotFound();

            return reminder;
        }

        // POST: api/careReminders
        [HttpPost]
        public async Task<ActionResult<CareReminder>> CreateReminder(CareReminder reminder)
        {
            _context.CareReminders.Add(reminder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReminder), new { id = reminder.Id }, reminder);
        }

        // PUT: api/careReminders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReminder(int id, CareReminder reminder)
        {
            if (id != reminder.Id)
                return BadRequest();

            _context.Entry(reminder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CareReminders.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return Ok(reminder);
        }

        // DELETE: api/careReminders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            var reminder = await _context.CareReminders.FindAsync(id);
            if (reminder == null)
                return NotFound();

            _context.CareReminders.Remove(reminder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
