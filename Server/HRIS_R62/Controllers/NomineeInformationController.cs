using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomineeInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NomineeInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NomineeInformation>>> GetAll()
        {
            return await _context.NomineeInformations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NomineeInformation>> GetById(string id)
        {
            var nominee = await _context.NomineeInformations.FindAsync(id);
            if (nominee == null)
                return NotFound();
            return nominee;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsingSP(NomineeInformation nominee)
        {
            var parameters = new[]
            {
                new SqlParameter("@NomineeID", nominee.NomineeID),
                new SqlParameter("@Name", nominee.Name ?? (object)DBNull.Value),
                new SqlParameter("@Occupation", nominee.Occupation ?? (object)DBNull.Value),
                new SqlParameter("@Relation", nominee.Relation ?? (object)DBNull.Value),
                new SqlParameter("@Age", nominee.Age),
                new SqlParameter("@Address", nominee.Address ?? (object)DBNull.Value),
                new SqlParameter("@Percentage", nominee.Percentage),
                new SqlParameter("@Flag", nominee.Flag ?? (object)DBNull.Value),
                new SqlParameter("@EmployeeID", nominee.EmployeeID)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC usp_CreateNomineeInformation @NomineeID, @Name, @Occupation, @Relation, @Age, @Address, @Percentage, @Flag, @EmployeeID", parameters);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, NomineeInformation nominee)
        {
            if (id != nominee.NomineeID)
                return BadRequest();

            _context.Entry(nominee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NomineeInformations.Any(e => e.NomineeID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var nominee = await _context.NomineeInformations.FindAsync(id);
            if (nominee == null)
                return NotFound();

            _context.NomineeInformations.Remove(nominee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
