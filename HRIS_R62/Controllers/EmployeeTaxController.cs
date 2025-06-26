using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaxController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeTaxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/EmployeeTax
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTax>>> GetEmployeeTaxes()
        {
            return await _context.EmployeeTaxes.Include(e => e.EmployeeInformation).ToListAsync();
        }

        // ✅ GET: api/EmployeeTax/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTax>> GetEmployeeTax(string id)
        {
            var employeeTax = await _context.EmployeeTaxes.Include(e => e.EmployeeInformation)
                                                          .FirstOrDefaultAsync(e => e.EmployeeTaxID == id);

            if (employeeTax == null)
            {
                return NotFound();
            }

            return employeeTax;
        }

        // ✅ POST: api/EmployeeTax
        [HttpPost]
        public async Task<ActionResult<EmployeeTax>> PostEmployeeTax(EmployeeTax employeeTax)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employeeTax.EmployeeTaxID = Guid.NewGuid().ToString();
            _context.EmployeeTaxes.Add(employeeTax);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeTax), new { id = employeeTax.EmployeeTaxID }, employeeTax);
        }

        // ✅ PUT: api/EmployeeTax/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTax(string id, EmployeeTax employeeTax)
        {
            if (id != employeeTax.EmployeeTaxID)
            {
                return BadRequest();
            }

            _context.Entry(employeeTax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EmployeeTaxes.Any(e => e.EmployeeTaxID == id))
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

        // ✅ DELETE: api/EmployeeTax/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTax(string id)
        {
            var employeeTax = await _context.EmployeeTaxes.FindAsync(id);
            if (employeeTax == null)
            {
                return NotFound();
            }

            _context.EmployeeTaxes.Remove(employeeTax);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
