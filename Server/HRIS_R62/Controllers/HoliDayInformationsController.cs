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
    public class HoliDayInformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HoliDayInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HoliDayInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoliDayInformation>>> GetHoliDayInformations()
        {
            return await _context.HoliDayInformations.ToListAsync();
        }

        // GET: api/HoliDayInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoliDayInformation>> GetHoliDayInformation(string id)
        {
            var holiDayInformation = await _context.HoliDayInformations.FindAsync(id);

            if (holiDayInformation == null)
            {
                return NotFound();
            }

            return holiDayInformation;
        }

        // PUT: api/HoliDayInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliDayInformation(string id, HoliDayInformation holiDayInformation)
        {
            if (id != holiDayInformation.HoliDayInformationID)
            {
                return BadRequest();
            }

            _context.Entry(holiDayInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoliDayInformationExists(id))
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



        // POST: api/HoliDayInformations
        
        [HttpPost]
        public async Task<IActionResult> InsertHoliDayInformation(HoliDayInformation holiDayInformation)
        {
            if (holiDayInformation == null)
            {
                return BadRequest("HoliDayEntitledEmployee is null.");
            }
            try
            {
                await _context.InsertHolidayainformationAsync(holiDayInformation);
                return Ok("HoliDayInformation insert ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }



        // DELETE: api/HoliDayInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliDayInformation(string id)
        {
            var holiDayInformation = await _context.HoliDayInformations.FindAsync(id);
            if (holiDayInformation == null)
            {
                return NotFound();
            }

            _context.HoliDayInformations.Remove(holiDayInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoliDayInformationExists(string id)
        {
            return _context.HoliDayInformations.Any(e => e.HoliDayInformationID == id);
        }
    }
}
