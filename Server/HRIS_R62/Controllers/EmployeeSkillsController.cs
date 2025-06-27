using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeSkillsController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSkill>>> GetEmployeeSkills()
        {
            return await _context.EmployeeSkills
                .Include(e => e.EmployeeInformation)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSkill>> GetEmployeeSkill(string id)
        {
            var employeeSkill = await _context.EmployeeSkills
                .Include(e => e.EmployeeInformation)
                .FirstOrDefaultAsync(e => e.SkillID == id);

            if (employeeSkill == null)
            {
                return NotFound();
            }

            return employeeSkill;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill(EmployeeSkill employeeSkill)
        {
            _context.EmployeeSkills.Add(employeeSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeSkill), new { id = employeeSkill.SkillID }, employeeSkill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill(string id, EmployeeSkill employeeSkill)
        {
            if (id != employeeSkill.SkillID)
            {
                return BadRequest("Skill ID mismatch.");
            }

            _context.Entry(employeeSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSkillExists(id))
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
        private bool EmployeeSkillExists(string id)
        {
            return _context.EmployeeSkills.Any(e => e.SkillID == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeSkill(string id)
        {
            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return NotFound();
            }

            _context.EmployeeSkills.Remove(employeeSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
