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
    public class AttendanceStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceStatus>>> GetAttendanceStatuss()
        {
            return await _context.AttendanceStatuss.ToListAsync();
        }

        // GET: api/AttendanceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceStatus>> GetAttendanceStatus(string id)
        {
            var attendanceStatus = await _context.AttendanceStatuss.FindAsync(id);

            if (attendanceStatus == null)
            {
                return NotFound();
            }

            return attendanceStatus;
        }

        // PUT: api/AttendanceStatus/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceStatus(string id, AttendanceStatus attendanceStatus)
        {
            if (id != attendanceStatus.AttendanceStatusID)
            {
                return BadRequest();
            }

            _context.Entry(attendanceStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceStatusExists(id))
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

        // POST: api/AttendanceStatus


        [HttpPost("sp")]
        public IActionResult CreateSp(string id,string stname,string stshortname)
        {
            AttendanceStatus tasu = new AttendanceStatus()
            {
                AttendanceStatusID = id,
                StatusName = stname,
                StatusShortName = stshortname
            };
            this._context.InsertAttendancestatus(tasu);
            return Ok("Insert Successful");
        }


        [HttpPost]
        public async Task<ActionResult<AttendanceStatus>> PostAttendanceStatus(AttendanceStatus attendanceStatus)
        {
            _context.AttendanceStatuss.Add(attendanceStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceStatusExists(attendanceStatus.AttendanceStatusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendanceStatus", new { id = attendanceStatus.AttendanceStatusID }, attendanceStatus);
        }

        // DELETE: api/AttendanceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceStatus(string id)
        {
            var attendanceStatus = await _context.AttendanceStatuss.FindAsync(id);
            if (attendanceStatus == null)
            {
                return NotFound();
            }

            _context.AttendanceStatuss.Remove(attendanceStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceStatusExists(string id)
        {
            return _context.AttendanceStatuss.Any(e => e.AttendanceStatusID == id);
        }
    }
}

