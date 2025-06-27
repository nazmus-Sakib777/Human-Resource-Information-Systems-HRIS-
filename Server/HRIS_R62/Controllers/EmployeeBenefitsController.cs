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
    public class EmployeeBenefitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeBenefitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeBenefits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBenefits>>> GetEmployeeBenefits()
        {
            return await _context.EmployeeBenefits.ToListAsync();
        }

        // GET: api/EmployeeBenefits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeBenefits>> GetEmployeeBenefits(string id)
        {
            var employeeBenefits = await _context.EmployeeBenefits.FindAsync(id);

            if (employeeBenefits == null)
            {
                return NotFound();
            }

            return employeeBenefits;
        }

        // PUT: api/EmployeeBenefits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeBenefits(string id, EmployeeBenefits employeeBenefits)
        {
            if (id != employeeBenefits.BenefitID)
            {
                return BadRequest();
            }

            _context.Entry(employeeBenefits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeBenefitsExists(id))
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



        // POST: api/EmployeeBenefits    
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeBenefit(EmployeeBenefits employeeBenefit)
        {
            if (employeeBenefit == null)
            {
                return BadRequest("EmployeeBenefit is null.");
            }
            try
            {
                await _context.InsertEmployeeBenefitAsync(employeeBenefit);
                return Ok("EmployeeBenefit insert ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }



        // DELETE: api/EmployeeBenefits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeBenefits(string id)
        {
            var employeeBenefits = await _context.EmployeeBenefits.FindAsync(id);
            if (employeeBenefits == null)
            {
                return NotFound();
            }

            _context.EmployeeBenefits.Remove(employeeBenefits);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeBenefitsExists(string id)
        {
            return _context.EmployeeBenefits.Any(e => e.BenefitID == id);
        }
    }
}
