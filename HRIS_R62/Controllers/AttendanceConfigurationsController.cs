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
    public class AttendanceConfigurationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceConfigurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceConfiguration>>> GetAttendanceConfigurations()
        {
            return await _context.AttendanceConfigurations.ToListAsync();
        }

        // GET: api/AttendanceConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceConfiguration>> GetAttendanceConfiguration(string id)
        {
            var attendanceConfiguration = await _context.AttendanceConfigurations.FindAsync(id);

            if (attendanceConfiguration == null)
            {
                return NotFound();
            }

            return attendanceConfiguration;
        }

        // PUT: api/AttendanceConfigurations/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceConfiguration(string id, AttendanceConfiguration attendanceConfiguration)
        {
            if (id != attendanceConfiguration.AttendanceConfigurationID)
            {
                return BadRequest();
            }

            _context.Entry(attendanceConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceConfigurationExists(id))
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

        // POST: api/AttendanceConfigurations

        [HttpPost]
        public async Task<ActionResult<AttendanceConfiguration>> PostAttendanceConfiguration(AttendanceConfiguration attendanceConfiguration)
        {
            _context.AttendanceConfigurations.Add(attendanceConfiguration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceConfigurationExists(attendanceConfiguration.AttendanceConfigurationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendanceConfiguration", new { id = attendanceConfiguration.AttendanceConfigurationID }, attendanceConfiguration);
        }

        // DELETE: api/AttendanceConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceConfiguration(string id)
        {
            var attendanceConfiguration = await _context.AttendanceConfigurations.FindAsync(id);
            if (attendanceConfiguration == null)
            {
                return NotFound();
            }

            _context.AttendanceConfigurations.Remove(attendanceConfiguration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceConfigurationExists(string id)
        {
            return _context.AttendanceConfigurations.Any(e => e.AttendanceConfigurationID == id);
        }
    }
}
