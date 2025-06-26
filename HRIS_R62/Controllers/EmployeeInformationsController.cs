using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeInformation>>> GetEmployeeInformations()
        {
            return await _context.EmployeeInformations.ToListAsync();
        }

        // GET: api/EmployeeInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInformation>> GetEmployeeInformation(string id)
        {
            var employee = await _context.EmployeeInformations.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/EmployeeInformations
        [HttpPost]
        public async Task<ActionResult<EmployeeInformation>> PostEmployeeInformation(EmployeeInformation employeeInformation)
        {
            _context.EmployeeInformations.Add(employeeInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeInformation), new { id = employeeInformation.EmployeeID }, employeeInformation);
        }

        // PUT: api/EmployeeInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInformation(string id, EmployeeInformation employeeInformation)
        {
            if (id != employeeInformation.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeeInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInformationExists(id))
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

        // DELETE: api/EmployeeInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeInformation(string id)
        {
            var employee = await _context.EmployeeInformations.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.EmployeeInformations.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeInformationExists(string id)
        {
            return _context.EmployeeInformations.Any(e => e.EmployeeID == id);
        }
    }
}
