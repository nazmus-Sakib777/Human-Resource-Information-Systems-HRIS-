using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS_R62.Models;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaryActionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DisciplinaryActionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DisciplinaryActions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaryAction>>> GetDisciplinaryActions()
        {
            return await _context.DisciplinaryActions.ToListAsync();
        }

        // GET: api/DisciplinaryActions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaryAction>> GetDisciplinaryAction(string id)
        {
            var disciplinaryAction = await _context.DisciplinaryActions.FindAsync(id);

            if (disciplinaryAction == null)
            {
                return NotFound();
            }

            return disciplinaryAction;
        }

        // PUT: api/DisciplinaryActions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplinaryAction(string id, DisciplinaryAction disciplinaryAction)
        {
            if (id != disciplinaryAction.ActionID)
            {
                return BadRequest();
            }

            _context.Entry(disciplinaryAction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaryActionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DisciplinaryActions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisciplinaryAction>> PostDisciplinaryAction(DisciplinaryAction disciplinaryAction)
        {
            _context.DisciplinaryActions.Add(disciplinaryAction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DisciplinaryActionExists(disciplinaryAction.ActionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDisciplinaryAction", new { id = disciplinaryAction.ActionID }, disciplinaryAction);
        }

        // DELETE: api/DisciplinaryActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplinaryAction(string id)
        {
            var disciplinaryAction = await _context.DisciplinaryActions.FindAsync(id);
            if (disciplinaryAction == null)
            {
                return NotFound();
            }

            _context.DisciplinaryActions.Remove(disciplinaryAction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplinaryActionExists(string id)
        {
            return _context.DisciplinaryActions.Any(e => e.ActionID == id);
        }
    }
}
