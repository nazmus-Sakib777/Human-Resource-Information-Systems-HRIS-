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
    public class ShiftTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShiftTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShiftTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftTime>>> GetShiftTimes()
        {
            return await _context.ShiftTimes.ToListAsync();
        }

        // GET: api/ShiftTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftTime>> GetShiftTime(string id)
        {
            var shiftTime = await _context.ShiftTimes.FindAsync(id);

            if (shiftTime == null)
            {
                return NotFound();
            }

            return shiftTime;
        }

        // PUT: api/ShiftTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftTime(string id, ShiftTime shiftTime)
        {
            if (id != shiftTime.ShiftID)
            {
                return BadRequest();
            }

            _context.Entry(shiftTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftTimeExists(id))
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

        // POST: api/ShiftTimes

            [HttpPost]
            public async Task<IActionResult> InsertShiftTime([FromBody] ShiftTime shiftTime)
            {
                if (shiftTime == null)
                {
                    return BadRequest("ShiftTime data is null.");
                }

                try
                {
                    await _context.InsertShiftTimeAsync(shiftTime);
                    return Ok("ShiftTime inserted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (optional)
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

        // DELETE: api/ShiftTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShiftTime(string id)
        {
            var shiftTime = await _context.ShiftTimes.FindAsync(id);
            if (shiftTime == null)
            {
                return NotFound();
            }

            _context.ShiftTimes.Remove(shiftTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftTimeExists(string id)
        {
            return _context.ShiftTimes.Any(e => e.ShiftID == id);
        }
    }
}
