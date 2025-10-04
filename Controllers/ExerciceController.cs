using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuscuApp.Data;
using MuscuApp.Models.Entities;

namespace MuscuApp.Controllers
{
    [ApiController] // no views, just pass data
    [Route("api/[controller]")]
    public class ExerciceController : ControllerBase
    {
        private readonly AppDbContext _context;
        // constructor injection
        public ExerciceController(AppDbContext context) //ctr
        {
            this._context = context;
        }

        // GET: api/exercice
        [HttpGet]
        public async Task<IActionResult> GetAllExercies()
        {
            // return success response
            return Ok(await _context.Exercices.ToListAsync());
        }

        // GET: api/exercice/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciceById([FromRoute] int id)
        {
            //await _context.Exercices.FirstOrDefaultAsync(x => x.Id == id);
            // or
            var exercice = await _context.Exercices.FindAsync(id);
            if (exercice == null)
            {
                return NotFound();
            }
            return Ok(exercice);
        }

        // POST: api/exercice
        [HttpPost]
        public async Task<IActionResult> AddExercice([FromBody] Exercice exercice)
        {
            if (exercice == null)
                return BadRequest("Exercice cannot be null.");

            // The Id will auto-increment because it's the primary key
            await _context.Exercices.AddAsync(exercice);
            await _context.SaveChangesAsync();

            // Returns 201 with a link to the created resource
            return CreatedAtAction(nameof(GetExerciceById), new { id = exercice.Id }, exercice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercice([FromRoute] int id, [FromBody] Exercice updatedExercice)
        {
            var existingExercice = await _context.Exercices.FindAsync(id);
            if (existingExercice == null)
            {
                return NotFound();
            }
            existingExercice.Name = updatedExercice.Name;
            existingExercice.Category = updatedExercice.Category;
            existingExercice.Description = updatedExercice.Description;

            await _context.SaveChangesAsync();

            return Ok(existingExercice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercice([FromRoute] int id)
        {
            var existingExercice = await _context.Exercices.FindAsync(id);
            if (existingExercice == null)
            {
                return NotFound();
            }

            _context.Exercices.Remove(existingExercice);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    
}
