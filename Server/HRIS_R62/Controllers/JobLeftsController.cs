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
    public class JobLeftsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobLeftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobLefts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobLeft>>> GetJobLefts()
        {
            return await _context.JobLefts.ToListAsync();
        }

        // GET: api/JobLefts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobLeft>> GetJobLeft(string id)
        {
            var jobLeft = await _context.JobLefts.FindAsync(id);

            if (jobLeft == null)
            {
                return NotFound();
            }

            return jobLeft;
        }

        // PUT: api/JobLefts/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobLeft(string id, JobLeft jobLeft)
        {
            if (id != jobLeft.JobLeftID)
            {
                return BadRequest();
            }

            _context.Entry(jobLeft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobLeftExists(id))
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

        // POST: api/JobLefts
        [HttpPost]
        public async Task<IActionResult> InsertJobLeft([FromBody] JobLeft jobLeft)
        {
            if (jobLeft == null)
                return BadRequest("JobLeft object is null");

            try
            {
                await _context.InsertJobLeftAsync(jobLeft);
                return Ok(new { message = "JobLeft inserted successfully" });
            }
            catch (Exception ex)
            {
                // You can log the exception here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/JobLefts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobLeft(string id)
        {
            var jobLeft = await _context.JobLefts.FindAsync(id);
            if (jobLeft == null)
            {
                return NotFound();
            }

            _context.JobLefts.Remove(jobLeft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobLeftExists(string id)
        {
            return _context.JobLefts.Any(e => e.JobLeftID == id);
        }
    }
}
