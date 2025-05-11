using AmigoPet.Data.Context;
using AmigoPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmigoPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemChecklistsController : ControllerBase
    {
        private readonly AmigoPetContext _context;

        public ItemChecklistsController(AmigoPetContext context)
        {
            _context = context;
        }

        // GET: api/ItemChecklists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemChecklist>>> GetItems()
        {
            return await _context.ItemChecklists.ToListAsync();
        }

        // GET: api/ItemChecklists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemChecklist>> GetItem(int id)
        {
            var item = await _context.ItemChecklists.FindAsync(id);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/ItemChecklists
        [HttpPost]
        public async Task<ActionResult<ItemChecklist>> CreateItem(ItemChecklist item)
        {
            _context.ItemChecklists.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/ItemChecklists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemChecklist item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ItemChecklists.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return Ok(item);
        }

        // DELETE: api/ItemChecklists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.ItemChecklists.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.ItemChecklists.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
