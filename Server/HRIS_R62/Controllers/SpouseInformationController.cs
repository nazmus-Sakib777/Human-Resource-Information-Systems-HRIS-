using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpouseInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpouseInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpouseInformation>>> GetAll()
        {
            return await _context.SpouseInformations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpouseInformation>> GetById(string id)
        {
            var spouse = await _context.SpouseInformations.FindAsync(id);
            if (spouse == null)
                return NotFound();
            return spouse;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsingSP(SpouseInformation spouse)
        {
            var parameters = new[]
            {
                new SqlParameter("@SpouseID", spouse.SpouseID ?? (object)DBNull.Value),
                new SqlParameter("@SpouseName", spouse.SpouseName ?? (object)DBNull.Value),
                new SqlParameter("@Occupation", spouse.Occupation ?? (object)DBNull.Value),
                new SqlParameter("@DateOfBirth", spouse.DateOfBirth ?? (object)DBNull.Value),
                new SqlParameter("@BloodGroup", spouse.BloodGroup ?? (object)DBNull.Value),
                new SqlParameter("@EmployeeID", spouse.EmployeeID ?? (object)DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC usp_CreateSpouseInformation @SpouseID, @SpouseName, @Occupation, @DateOfBirth, @BloodGroup, @EmployeeID", parameters);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, SpouseInformation spouse)
        {
            if (id != spouse.SpouseID)
                return BadRequest();

            _context.Entry(spouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SpouseInformations.Any(e => e.SpouseID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var spouse = await _context.SpouseInformations.FindAsync(id);
            if (spouse == null)
                return NotFound();

            _context.SpouseInformations.Remove(spouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
