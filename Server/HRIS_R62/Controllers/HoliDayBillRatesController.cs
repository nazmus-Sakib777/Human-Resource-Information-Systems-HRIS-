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
    public class HoliDayBillRatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HoliDayBillRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HoliDayBillRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoliDayBillRate>>> GetHoliDayBillRates()
        {
            return await _context.HoliDayBillRates.ToListAsync();
        }

        // GET: api/HoliDayBillRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoliDayBillRate>> GetHoliDayBillRate(string id)
        {
            var holiDayBillRate = await _context.HoliDayBillRates.FindAsync(id);

            if (holiDayBillRate == null)
            {
                return NotFound();
            }

            return holiDayBillRate;
        }

        // PUT: api/HoliDayBillRates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliDayBillRate(string id, HoliDayBillRate holiDayBillRate)
        {
            if (id != holiDayBillRate.HoliDayBillRateID)
            {
                return BadRequest();
            }

            _context.Entry(holiDayBillRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoliDayBillRateExists(id))
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



        // POST: api/HoliDayBillRates
        [HttpPost]
        public async Task<IActionResult> InsertHolidayBillRate(HoliDayBillRate holiDayBillRate)
        {
            if (holiDayBillRate == null)
            {
                return BadRequest("HolidayBillRate is null.");
            }
            try
            {
                await _context.InsertHolidayBillRateAsync(holiDayBillRate);
                return Ok("HolidayBillRate insert ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }



        // DELETE: api/HoliDayBillRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliDayBillRate(string id)
        {
            var holiDayBillRate = await _context.HoliDayBillRates.FindAsync(id);
            if (holiDayBillRate == null)
            {
                return NotFound();
            }

            _context.HoliDayBillRates.Remove(holiDayBillRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoliDayBillRateExists(string id)
        {
            return _context.HoliDayBillRates.Any(e => e.HoliDayBillRateID == id);
        }
    }
}
