using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManualAttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManualAttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManualAttendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManualAttendance>>> GetManualAttendances()
        {
            return await _context.ManualAttendances
                                 .Include(m => m.EmployeeInformation) // navigation load
                                 .ToListAsync();
        }

        // GET: api/ManualAttendance/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ManualAttendance>> GetManualAttendance(string id)
        {
            var attendance = await _context.ManualAttendances
                                           .Include(m => m.EmployeeInformation)
                                           .FirstOrDefaultAsync(m => m.ManualAttendanceID == id);

            if (attendance == null)
                return NotFound();

            return attendance;
        }

        //POST with SP
        [HttpPost("sp")]
        public IActionResult CreateSp(string id, DateTime adate, string atime, DateTime edate, string reason, string laclear, string laremarks, DateTime appdate, string euser, string outtime, string remarks, string empId)
        {
            ManualAttendance tasu = new ManualAttendance()
            {
                ManualAttendanceID = id,
                AttendanceDate = adate,
                AttendanceTime = atime,
                EntryDate = edate,
                Reason = reason,
                LocalAreaClerance = laclear,
                LocalAreaRemarks = remarks,
                ApprovedDate = appdate,
                EntryUser = euser,
                OutTime = outtime,
                Remarks = remarks,
                EmployeeID = empId


            };
            this._context.InsertManualAtt(tasu);
            return Ok("Insert Successful");
        }


        // POST: api/ManualAttendance
        [HttpPost]
        public async Task<ActionResult<ManualAttendance>> PostManualAttendance(ManualAttendance manualAttendance)
        {
            _context.ManualAttendances.Add(manualAttendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManualAttendance), new { id = manualAttendance.ManualAttendanceID }, manualAttendance);
        }

        // PUT: api/ManualAttendance/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManualAttendance(string id, ManualAttendance manualAttendance)
        {
            if (id != manualAttendance.ManualAttendanceID)
                return BadRequest();

            _context.Entry(manualAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManualAttendanceExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/ManualAttendance/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManualAttendance(string id)
        {
            var attendance = await _context.ManualAttendances.FindAsync(id);
            if (attendance == null)
                return NotFound();

            _context.ManualAttendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManualAttendanceExists(string id)
        {
            return _context.ManualAttendances.Any(e => e.ManualAttendanceID == id);
        }
    }
}
