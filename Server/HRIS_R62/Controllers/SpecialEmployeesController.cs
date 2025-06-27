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
    public class SpecialEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpecialEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SpecialEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialEmployee>>> GetSpecialEmployees()
        {
            return await _context.SpecialEmployees.ToListAsync();
        }

        // GET: api/SpecialEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialEmployee>> GetSpecialEmployee(string id)
        {
            var specialEmployee = await _context.SpecialEmployees.FindAsync(id);

            if (specialEmployee == null)
            {
                return NotFound();
            }

            return specialEmployee;
        }

        // PUT: api/SpecialEmployees/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialEmployee(string id, SpecialEmployee specialEmployee)
        {
            if (id != specialEmployee.SpecialEmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(specialEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialEmployeeExists(id))
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

        // POST: api/SpecialEmployees
        [HttpPost]
        public async Task<IActionResult> InsertSpecialEmployee([FromBody] SpecialEmployee specialEmployee)
        {
            if (specialEmployee == null)
                return BadRequest("SpecialEmployee object is null");

            try
            {
                await _context.InsertSpecialEmployeeAsync(specialEmployee);
                return Ok(new { message = "SpecialEmployee inserted successfully" });
            }
            catch (Exception ex)
            {
                // You can log the error here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/SpecialEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialEmployee(string id)
        {
            var specialEmployee = await _context.SpecialEmployees.FindAsync(id);
            if (specialEmployee == null)
            {
                return NotFound();
            }

            _context.SpecialEmployees.Remove(specialEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialEmployeeExists(string id)
        {
            return _context.SpecialEmployees.Any(e => e.SpecialEmployeeID == id);
        }
    }
}
