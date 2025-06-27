using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRIS_R62.Controllers
{
    //ProximityRecord
    [Route("api/[controller]")]
    [ApiController]
    public class ProximityRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProximityRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProximityRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProximityRecord>>> GetProximityRecords()
        {
            return await _context.ProximityRecords
                .Include(pr => pr.EmployeeInformation) // Include if you need employee info
                .ToListAsync();
        }

        // GET: api/ProximityRecord/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProximityRecord>> GetProximityRecord(string id)
        {
            var record = await _context.ProximityRecords
                .Include(pr => pr.EmployeeInformation)
                .FirstOrDefaultAsync(pr => pr.ProximityRecordID == id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // POST: api/ProximityRecord
        [HttpPost]
        public async Task<ActionResult<ProximityRecord>> PostProximityRecord(ProximityRecord proximityRecord)
        {
            _context.ProximityRecords.Add(proximityRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProximityRecord), new { id = proximityRecord.ProximityRecordID }, proximityRecord);
        }

        // PUT: api/ProximityRecord/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProximityRecord(string id, ProximityRecord proximityRecord)
        {
            if (id != proximityRecord.ProximityRecordID)
            {
                return BadRequest();
            }

            _context.Entry(proximityRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProximityRecordExists(id))
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

        // DELETE: api/ProximityRecord/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProximityRecord(string id)
        {
            var record = await _context.ProximityRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.ProximityRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProximityRecordExists(string id)
        {
            return _context.ProximityRecords.Any(e => e.ProximityRecordID == id);
        }
    }
}
