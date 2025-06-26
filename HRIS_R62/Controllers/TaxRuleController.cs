using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRuleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxRuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaxRule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxRule>>> GetTaxRules()
        {
            return await _context.TaxRules.ToListAsync();
        }

        // GET: api/TaxRule/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxRule>> GetTaxRule(string id)
        {
            var taxRule = await _context.TaxRules.FindAsync(id);

            if (taxRule == null)
            {
                return NotFound();
            }

            return taxRule;
        }

        // POST: api/TaxRule
        [HttpPost]
        public async Task<ActionResult<TaxRule>> PostTaxRule(TaxRule taxRule)
        {
            _context.TaxRules.Add(taxRule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaxRule), new { id = taxRule.TaxRuleID }, taxRule);
        }

        // PUT: api/TaxRule/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxRule(string id, TaxRule taxRule)
        {
            if (id != taxRule.TaxRuleID)
            {
                return BadRequest("ID mismatch");
            }

            _context.Entry(taxRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxRuleExists(id))
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

        // DELETE: api/TaxRule/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxRule(string id)
        {
            var taxRule = await _context.TaxRules.FindAsync(id);
            if (taxRule == null)
            {
                return NotFound();
            }

            _context.TaxRules.Remove(taxRule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxRuleExists(string id)
        {
            return _context.TaxRules.Any(e => e.TaxRuleID == id);
        }
    }
}
