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
    public class HoliDayEntitledEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HoliDayEntitledEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HoliDayEntitledEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoliDayEntitledEmployee>>> GetHoliDayEntitledEmployees()
        {
            return await _context.HoliDayEntitledEmployees.ToListAsync();
        }

        // GET: api/HoliDayEntitledEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoliDayEntitledEmployee>> GetHoliDayEntitledEmployee(string id)
        {
            var holiDayEntitledEmployee = await _context.HoliDayEntitledEmployees.FindAsync(id);

            if (holiDayEntitledEmployee == null)
            {
                return NotFound();
            }

            return holiDayEntitledEmployee;
        }

        // PUT: api/HoliDayEntitledEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliDayEntitledEmployee(string id, HoliDayEntitledEmployee holiDayEntitledEmployee)
        {
            if (id != holiDayEntitledEmployee.HoliDayEntitledEmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(holiDayEntitledEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoliDayEntitledEmployeeExists(id))
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



        // POST: api/HoliDayEntitledEmployees
        [HttpPost]
        public async Task<IActionResult> InsertHolidayEntitledEmployee(HoliDayEntitledEmployee holiDayEntitledEmployee)
        {
            if (holiDayEntitledEmployee == null)
            {
                return BadRequest("HoliDayEntitledEmployee is null.");
            }
            try
            {
                await _context.InsertHolidayEntitledEmployeeAsync(holiDayEntitledEmployee);
                return Ok("HolidayBillRate insert ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }



        // DELETE: api/HoliDayEntitledEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliDayEntitledEmployee(string id)
        {
            var holiDayEntitledEmployee = await _context.HoliDayEntitledEmployees.FindAsync(id);
            if (holiDayEntitledEmployee == null)
            {
                return NotFound();
            }

            _context.HoliDayEntitledEmployees.Remove(holiDayEntitledEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoliDayEntitledEmployeeExists(string id)
        {
            return _context.HoliDayEntitledEmployees.Any(e => e.HoliDayEntitledEmployeeID == id);
        }
    }
}
