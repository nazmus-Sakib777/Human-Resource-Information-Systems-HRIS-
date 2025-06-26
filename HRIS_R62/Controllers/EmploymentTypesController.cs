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
    public class EmploymentTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmploymentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentType>>> GetEmploymentTypes()
        {
            return await _context.EmploymentTypes.ToListAsync();
        }

        // GET: api/EmploymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentType>> GetEmploymentType(string id)
        {
            var employmentType = await _context.EmploymentTypes.FindAsync(id);

            if (employmentType == null)
            {
                return NotFound();
            }

            return employmentType;
        }

        // PUT: api/EmploymentTypes/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentType(string id, EmploymentType employmentType)
        {
            if (id != employmentType.EmploymentTypeID)
            {
                return BadRequest();
            }

            _context.Entry(employmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentTypeExists(id))
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

        // POST: api/EmploymentTypes
        [HttpPost]
        public async Task<IActionResult> InsertEmploymentType([FromBody] EmploymentType employmentType)
        {
            if (employmentType == null)
            {
                return BadRequest("EmploymentType is null.");
            }

            try
            {
                await _context.InsertEmploymentTypeAsync(employmentType);
                return Ok("EmploymentType inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/EmploymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentType(string id)
        {
            var employmentType = await _context.EmploymentTypes.FindAsync(id);
            if (employmentType == null)
            {
                return NotFound();
            }

            _context.EmploymentTypes.Remove(employmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentTypeExists(string id)
        {
            return _context.EmploymentTypes.Any(e => e.EmploymentTypeID == id);
        }
    }
}
