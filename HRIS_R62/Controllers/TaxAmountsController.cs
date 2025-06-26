using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxAmountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxAmountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaxAmounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxAmount>>> GetTaxAmounts()
        {
            return await _context.TaxAmounts.ToListAsync();
        }

        // GET: api/TaxAmounts/TAX001
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxAmount>> GetTaxAmount(string id)
        {
            var taxAmount = await _context.TaxAmounts.FindAsync(id);

            if (taxAmount == null)
            {
                return NotFound();
            }

            return taxAmount;
        }

        // POST: api/TaxAmounts
        [HttpPost]
        public async Task<ActionResult<TaxAmount>> PostTaxAmount(TaxAmount taxAmount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TaxAmounts.Add(taxAmount);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaxAmount), new { id = taxAmount.TaxAmountID }, taxAmount);
        }

        // PUT: api/TaxAmounts/TAX001
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxAmount(string id, TaxAmount taxAmount)
        {
            if (id != taxAmount.TaxAmountID)
            {
                return BadRequest("TaxAmountID mismatch.");
            }

            _context.Entry(taxAmount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxAmountExists(id))
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

        // DELETE: api/TaxAmounts/TAX001
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxAmount(string id)
        {
            var taxAmount = await _context.TaxAmounts.FindAsync(id);
            if (taxAmount == null)
            {
                return NotFound();
            }

            _context.TaxAmounts.Remove(taxAmount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxAmountExists(string id)
        {
            return _context.TaxAmounts.Any(e => e.TaxAmountID == id);
        }
    }
}
