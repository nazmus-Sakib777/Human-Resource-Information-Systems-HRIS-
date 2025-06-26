using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS_R62.Models;
using Microsoft.Data.SqlClient;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CareerHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CareerHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareerHistory>>> GetCareerHistories()
        {
            return await _context.CareerHistories.ToListAsync();
        }

        // GET: api/CareerHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareerHistory>> GetCareerHistory(string id)
        {
            var careerHistory = await _context.CareerHistories.FindAsync(id);

            if (careerHistory == null)
            {
                return NotFound();
            }

            return careerHistory;
        }

        // PUT: api/CareerHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerHistory(string id, CareerHistory careerHistory)
        {
            if (id != careerHistory.EntryNumber)
            {
                return BadRequest();
            }

            _context.Entry(careerHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerHistoryExists(id))
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

        // POST: api/CareerHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<int> InsertCareerHistoryAsync(CareerHistory history)
        //{
        //    return await Database.ExecuteSqlRawAsync(
        //        "EXEC sp_CareerHistory_Insert @EntryNumber = {0}, @EmployeeID = {1}, @EntryType = {2}, @EntryDate = {3}, @Description = {4}",
        //        history.EntryNumber,
        //        history.EmployeeID,
        //        history.EntryType,
        //        history.EntryDate,
        //        history.Description
        //    );
        //}
        public async Task<IActionResult> CreateUsingSP(CareerHistory history)
        {
            var parameters = new[]
            {
                new SqlParameter("@EntryNumber", history.EntryNumber ?? (object)DBNull.Value),
                new SqlParameter("@EmployeeID", history.EmployeeID ?? (object)DBNull.Value),
                new SqlParameter("@EntryType", history.EntryType ?? (object)DBNull.Value),
                new SqlParameter("@EntryDate", history.EntryDate ?? (object)DBNull.Value),
                new SqlParameter("@Description", history.Description ?? (object)DBNull.Value)
               
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CareerHistory_Insert @EntryNumber, @EmployeeID, @EntryType, @EntryDate, @Description", parameters);
            return Ok("inserted");
        }

        // DELETE: api/CareerHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareerHistory(string id)
        {
            var careerHistory = await _context.CareerHistories.FindAsync(id);
            if (careerHistory == null)
            {
                return NotFound();
            }

            _context.CareerHistories.Remove(careerHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerHistoryExists(string id)
        {
            return _context.CareerHistories.Any(e => e.EntryNumber == id);
        }
    }
}
