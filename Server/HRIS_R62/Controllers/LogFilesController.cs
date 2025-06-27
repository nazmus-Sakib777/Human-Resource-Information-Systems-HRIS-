using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogFilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LogFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LogFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogFile>>> GetLogFiles()
        {
            return await _context.LogFiles.ToListAsync();
        }

        // GET: api/LogFiles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LogFile>> GetLogFile(Guid id)
        {
            var log = await _context.LogFiles.FindAsync(id);
            if (log == null)
                return NotFound();

            return log;
        }

        // POST: api/LogFiles
        [HttpPost]
        public async Task<ActionResult<LogFile>> CreateLogFile(LogFile log)
        {
            log.LogID = Guid.NewGuid();
            _context.LogFiles.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLogFile), new { id = log.LogID }, log);
        }

        // PUT: api/LogFiles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogFile(Guid id, LogFile updatedLog)
        {
            if (id != updatedLog.LogID)
                return BadRequest();

            _context.Entry(updatedLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/LogFiles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogFile(Guid id)
        {
            var log = await _context.LogFiles.FindAsync(id);
            if (log == null)
                return NotFound();

            _context.LogFiles.Remove(log);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
