using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendance
        [HttpGet]
        public async Task<IActionResult> GetAllAttendanceRecords()
        {
            var records = await _context.AttendanceRecords.ToListAsync();
            return Ok(records);
        }

        // GET: api/Attendance/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceRecord(string id)
        {
            var record = await _context.AttendanceRecords
                .Include(r => r.AttendanceConfiguration)
                .Include(r => r.AttendanceStatus)
                .FirstOrDefaultAsync(r => r.AttendanceRecordID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // POST: api/Attendance
        [HttpPost]
        public async Task<IActionResult> CreateAttendanceRecord([FromBody] AttendanceRecord attendance)
        {
            var parameters = new[]
            {
                new SqlParameter("@AttendanceRecordID", attendance.AttendanceRecordID),
                new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
                new SqlParameter("@InTime", attendance.InTime),
                new SqlParameter("@OutTime", attendance.OutTime),
                new SqlParameter("@OTStart", attendance.OTStart),
                new SqlParameter("@OTEnd", attendance.OTEnd),
                new SqlParameter("@TotalRegularHours", attendance.TotalRegularHours),
                new SqlParameter("@TotalOvertimeHours", attendance.TotalOvertimeHours),
                new SqlParameter("@DayType", attendance.DayType),
                new SqlParameter("@AttendanceConfigurationID", attendance.AttendanceConfigurationID),
                new SqlParameter("@AttendanceStatusID", attendance.AttendanceStatusID)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertAttendanceRecord @AttendanceRecordID, @AttendanceDate, @InTime, @OutTime, @OTStart, @OTEnd, @TotalRegularHours, @TotalOvertimeHours, @DayType, @AttendanceConfigurationID, @AttendanceStatusID", parameters);

            return CreatedAtAction(nameof(GetAttendanceRecord), new { id = attendance.AttendanceRecordID }, attendance);
        }

        // PUT: api/Attendance/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendanceRecord(string id, [FromBody] AttendanceRecord attendance)
        {
            if (id != attendance.AttendanceRecordID)
                return BadRequest();

            var parameters = new[]
            {
                new SqlParameter("@AttendanceRecordID", attendance.AttendanceRecordID),
                new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
                new SqlParameter("@InTime", attendance.InTime),
                new SqlParameter("@OutTime", attendance.OutTime),
                new SqlParameter("@OTStart", attendance.OTStart),
                new SqlParameter("@OTEnd", attendance.OTEnd),
                new SqlParameter("@TotalRegularHours", attendance.TotalRegularHours),
                new SqlParameter("@TotalOvertimeHours", attendance.TotalOvertimeHours),
                new SqlParameter("@DayType", attendance.DayType),
                new SqlParameter("@AttendanceConfigurationID", attendance.AttendanceConfigurationID),
                new SqlParameter("@AttendanceStatusID", attendance.AttendanceStatusID)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateAttendanceRecord @AttendanceRecordID, @AttendanceDate, @InTime, @OutTime, @OTStart, @OTEnd, @TotalRegularHours, @TotalOvertimeHours, @DayType, @AttendanceConfigurationID, @AttendanceStatusID", parameters);

            return NoContent();
        }

        // DELETE: api/Attendance/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceRecord(string id)
        {
            var parameters = new[]
            {
                new SqlParameter("@AttendanceRecordID", id)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteAttendanceRecord @AttendanceRecordID", parameters);

            return NoContent();
        }
    }

}
