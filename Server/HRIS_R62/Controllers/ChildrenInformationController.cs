using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChildrenInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildrenInformation>>> GetAll()
        {
            return await _context.ChildrenInformations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChildrenInformation>> GetById(string id)
        {
            var child = await _context.ChildrenInformations.FindAsync(id);
            if (child == null)
                return NotFound();
            return child;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsingSP(ChildrenInformation child)
        {
            var parameters = new[]
            {
                new SqlParameter("@ChildID", child.ChildID),
                new SqlParameter("@ChildrenName", child.ChildrenName),
                new SqlParameter("@DateOfBirth", child.DateOfBirth ?? (object)DBNull.Value),
                new SqlParameter("@Age", child.Age),
                new SqlParameter("@Gender", child.Gender ?? (object)DBNull.Value),
                new SqlParameter("@BloodGroup", child.BloodGroup ?? (object)DBNull.Value),
                new SqlParameter("@MaritalStatus", child.MaritalStatus ?? (object)DBNull.Value),
                new SqlParameter("@EmployeeID", child.EmployeeID),
                new SqlParameter("@Flag", child.Flag ?? (object)DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC usp_CreateChildrenInformation @ChildID, @ChildrenName, @DateOfBirth, @Age, @Gender, @BloodGroup, @MaritalStatus, @EmployeeID, @Flag", parameters);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ChildrenInformation child)
        {
            if (id != child.ChildID)
                return BadRequest();

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ChildrenInformations.Any(e => e.ChildID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var child = await _context.ChildrenInformations.FindAsync(id);
            if (child == null)
                return NotFound();

            _context.ChildrenInformations.Remove(child);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
