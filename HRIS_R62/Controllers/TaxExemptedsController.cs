using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxExemptedsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxExemptedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaxExempteds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxExempted>>> GetTaxExempteds()
        {
            return await _context.TaxExempteds.Include(x => x.EmployeeInformations).ToListAsync();
        }

        // GET: api/TaxExempteds/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxExempted>> GetTaxExempted(string id)
        {
            var taxExempted = await _context.TaxExempteds
                .Include(x => x.EmployeeInformations)
                .FirstOrDefaultAsync(x => x.TaxExemptedID == id);

            if (taxExempted == null)
            {
                return NotFound();
            }

            return taxExempted;
        }

        // POST: api/TaxExempteds
        [HttpPost]
        public async Task<ActionResult<TaxExempted>> PostTaxExempted(TaxExempted taxExempted)
        {
            taxExempted.TaxExemptedID = Guid.NewGuid().ToString(); // Auto-generate ID
            _context.TaxExempteds.Add(taxExempted);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaxExempted), new { id = taxExempted.TaxExemptedID }, taxExempted);
        }

        // PUT: api/TaxExempteds/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxExempted(string id, TaxExempted taxExempted)
        {
            if (id != taxExempted.TaxExemptedID)
            {
                return BadRequest();
            }

            _context.Entry(taxExempted).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxExemptedExists(id))
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

        // DELETE: api/TaxExempteds/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxExempted(string id)
        {
            var taxExempted = await _context.TaxExempteds.FindAsync(id);
            if (taxExempted == null)
            {
                return NotFound();
            }

            _context.TaxExempteds.Remove(taxExempted);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxExemptedExists(string id)
        {
            return _context.TaxExempteds.Any(e => e.TaxExemptedID == id);
        }
    }
}
