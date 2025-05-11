using AmigoPet.Data.Context;
using AmigoPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmigoPet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly AmigoPetContext _context;

        public PetsController(AmigoPetContext context)
        {
            _context = context;
        }

        // GET: api/pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pets.ToListAsync();
        }

        // GET: api/pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound();

            return pet;
        }

        // POST: api/pets
        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        // PUT: api/pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet pet)
        {
            if (id != pet.Id)
                return BadRequest();

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pets.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return Ok(pet);
        }

        // DELETE: api/pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
                return NotFound();

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
