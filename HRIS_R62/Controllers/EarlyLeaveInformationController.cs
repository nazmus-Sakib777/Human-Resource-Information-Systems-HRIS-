using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarlyLeaveInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EarlyLeaveInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EarlyLeaveInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EarlyLeaveInformation>>> GetEarlyLeaveInformations()
        {
            return await _context.EarlyLeaveInformation
                                 .Include(e => e.EmployeeInformation)
                                 .ToListAsync();
        }

        // GET: api/EarlyLeaveInformation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EarlyLeaveInformation>> GetEarlyLeaveInformation(string id)
        {
            var earlyLeave = await _context.EarlyLeaveInformation
                                           .Include(e => e.EmployeeInformation)
                                           .FirstOrDefaultAsync(e => e.EarlyLeaveInformationID == id);

            if (earlyLeave == null)
                return NotFound();

            return earlyLeave;
        }

        // POST: api/EarlyLeaveInformation
        [HttpPost]
        public async Task<ActionResult<EarlyLeaveInformation>> PostEarlyLeaveInformation(EarlyLeaveInformation earlyLeaveInformation)
        {
            _context.EarlyLeaveInformation.Add(earlyLeaveInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEarlyLeaveInformation), new { id = earlyLeaveInformation.EarlyLeaveInformationID }, earlyLeaveInformation);
        }

        // PUT: api/EarlyLeaveInformation/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEarlyLeaveInformation(string id, EarlyLeaveInformation earlyLeaveInformation)
        {
            if (id != earlyLeaveInformation.EarlyLeaveInformationID)
                return BadRequest();

            _context.Entry(earlyLeaveInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EarlyLeaveInformationExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/EarlyLeaveInformation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEarlyLeaveInformation(string id)
        {
            var earlyLeave = await _context.EarlyLeaveInformation.FindAsync(id);
            if (earlyLeave == null)
                return NotFound();

            _context.EarlyLeaveInformation.Remove(earlyLeave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EarlyLeaveInformationExists(string id)
        {
            return _context.EarlyLeaveInformation.Any(e => e.EarlyLeaveInformationID == id);
        }
    }
}
