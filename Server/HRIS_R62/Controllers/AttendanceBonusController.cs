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
    public class AttendanceBonusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceBonusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceBonus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceBonus>>> GetAttendanceBonus()
        {
            return await _context.AttendanceBonus.ToListAsync();
        }

        // GET: api/AttendanceBonus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceBonus>> GetAttendanceBonus(string id)
        {
            var attendanceBonus = await _context.AttendanceBonus.FindAsync(id);

            if (attendanceBonus == null)
            {
                return NotFound();
            }

            return attendanceBonus;
        }

        // PUT: api/AttendanceBonus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceBonus(string id, AttendanceBonus attendanceBonus)
        {
            if (id != attendanceBonus.AttendanceBonusID)
            {
                return BadRequest();
            }

            _context.Entry(attendanceBonus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceBonusExists(id))
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

        // POST: api/AttendanceBonus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttendanceBonus>> PostAttendanceBonus(AttendanceBonus attendanceBonus)
        {
            _context.AttendanceBonus.Add(attendanceBonus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceBonusExists(attendanceBonus.AttendanceBonusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendanceBonus", new { id = attendanceBonus.AttendanceBonusID }, attendanceBonus);
        }

        // DELETE: api/AttendanceBonus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceBonus(string id)
        {
            var attendanceBonus = await _context.AttendanceBonus.FindAsync(id);
            if (attendanceBonus == null)
            {
                return NotFound();
            }

            _context.AttendanceBonus.Remove(attendanceBonus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceBonusExists(string id)
        {
            return _context.AttendanceBonus.Any(e => e.AttendanceBonusID == id);
        }
    }
}
