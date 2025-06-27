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
    public class DateWiseOfficeTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DateWiseOfficeTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DateWiseOfficeTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateWiseOfficeTime>>> GetDateWiseOfficeTimes()
        {
            return await _context.DateWiseOfficeTimes.ToListAsync();
        }

        // GET: api/DateWiseOfficeTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DateWiseOfficeTime>> GetDateWiseOfficeTime(string id)
        {
            var dateWiseOfficeTime = await _context.DateWiseOfficeTimes.FindAsync(id);

            if (dateWiseOfficeTime == null)
            {
                return NotFound();
            }

            return dateWiseOfficeTime;
        }
        //POST with SP
        [HttpPost("sp")]
        public IActionResult CreateSp(string DateWiseId, DateTime start, DateTime end, TimeOnly lunch, TimeOnly breakDuration, string empId)
        {
            DateWiseOfficeTime dateWise = new DateWiseOfficeTime()
            {
                DateWiseOfficeTimeID = DateWiseId,
                ShiftStartDateTime = start,
                ShiftEndDateTime = end,
                ConsideredLunchHour = lunch,
                BreakDuration = breakDuration,
                //EmployeeID = empId
            };
            this._context.InsertDateWiseTime(dateWise);
            return Ok("Insert Successful");
        }
        // PUT: api/DateWiseOfficeTimes/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDateWiseOfficeTime(string id, DateWiseOfficeTime dateWiseOfficeTime)
        {
            if (id != dateWiseOfficeTime.DateWiseOfficeTimeID)
            {
                return BadRequest();
            }

            _context.Entry(dateWiseOfficeTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DateWiseOfficeTimeExists(id))
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

        // POST: api/DateWiseOfficeTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DateWiseOfficeTime>> PostDateWiseOfficeTime(DateWiseOfficeTime dateWiseOfficeTime)
        {
            _context.DateWiseOfficeTimes.Add(dateWiseOfficeTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DateWiseOfficeTimeExists(dateWiseOfficeTime.DateWiseOfficeTimeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDateWiseOfficeTime", new { id = dateWiseOfficeTime.DateWiseOfficeTimeID }, dateWiseOfficeTime);
        }

        //// DELETE: api/DateWiseOfficeTimes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDateWiseOfficeTime(string id)
        //{
        //    var dateWiseOfficeTime = await _context.DateWiseOfficeTimes.FindAsync(id);
        //    if (dateWiseOfficeTime == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DateWiseOfficeTimes.Remove(dateWiseOfficeTime);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool DateWiseOfficeTimeExists(string id)
        {
            return _context.DateWiseOfficeTimes.Any(e => e.DateWiseOfficeTimeID == id);
        }
    }
}
