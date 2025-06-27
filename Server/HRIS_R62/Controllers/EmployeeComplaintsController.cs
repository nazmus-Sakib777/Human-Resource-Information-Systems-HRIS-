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
    public class EmployeeComplaintsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeComplaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeComplaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeComplaint>>> GetEmployeeComplaints()
        {
            return await _context.EmployeeComplaints.ToListAsync();
        }

        // GET: api/EmployeeComplaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeComplaint>> GetEmployeeComplaint(string id)
        {
            var employeeComplaint = await _context.EmployeeComplaints.FindAsync(id);

            if (employeeComplaint == null)
            {
                return NotFound();
            }

            return employeeComplaint;
        }

        // PUT: api/EmployeeComplaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeComplaint(string id, EmployeeComplaint employeeComplaint)
        {
            if (id != employeeComplaint.ComplaintID)
            {
                return BadRequest();
            }

            _context.Entry(employeeComplaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeComplaintExists(id))
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

        // POST: api/EmployeeComplaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeComplaint>> PostEmployeeComplaint(EmployeeComplaint employeeComplaint)
        {
            _context.EmployeeComplaints.Add(employeeComplaint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeComplaintExists(employeeComplaint.ComplaintID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeComplaint", new { id = employeeComplaint.ComplaintID }, employeeComplaint);
        }

        // DELETE: api/EmployeeComplaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeComplaint(string id)
        {
            var employeeComplaint = await _context.EmployeeComplaints.FindAsync(id);
            if (employeeComplaint == null)
            {
                return NotFound();
            }

            _context.EmployeeComplaints.Remove(employeeComplaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeComplaintExists(string id)
        {
            return _context.EmployeeComplaints.Any(e => e.ComplaintID == id);
        }
    }
}
