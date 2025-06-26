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
    public class SuspendsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuspendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Suspends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suspend>>> GetSuspends()
        {
            return await _context.Suspends.ToListAsync();
        }

        // GET: api/Suspends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suspend>> GetSuspend(string id)
        {
            var suspend = await _context.Suspends.FindAsync(id);

            if (suspend == null)
            {
                return NotFound();
            }

            return suspend;
        }

        // PUT: api/Suspends/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuspend(string id, Suspend suspend)
        {
            if (id != suspend.SuspendID)
            {
                return BadRequest();
            }

            _context.Entry(suspend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspendExists(id))
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

        // POST: api/Suspends

        [HttpPost]
        public async Task<IActionResult> InsertSuspend([FromBody] Suspend suspend)
        {
            if (suspend == null)
                return BadRequest("Suspend object is null");

            try
            {
                await _context.InsertSuspendAsync(suspend);
                return Ok(new { message = "Suspend record inserted successfully" });
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Suspends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuspend(string id)
        {
            var suspend = await _context.Suspends.FindAsync(id);
            if (suspend == null)
            {
                return NotFound();
            }

            _context.Suspends.Remove(suspend);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuspendExists(string id)
        {
            return _context.Suspends.Any(e => e.SuspendID == id);
        }
    }
}
