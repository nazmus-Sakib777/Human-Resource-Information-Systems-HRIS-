using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS_R62.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Data.SqlClient;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonInformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactPersonInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactPersonInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPersonInformation>>> GetContactPersonInformations()
        {
            return await _context.ContactPersonInformations.ToListAsync();
        }

        // GET: api/ContactPersonInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPersonInformation>> GetContactPersonInformation(string id)
        {
            var contactPersonInformation = await _context.ContactPersonInformations.FindAsync(id);

            if (contactPersonInformation == null)
            {
                return NotFound();
            }

            return contactPersonInformation;
        }

        // PUT: api/ContactPersonInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPersonInformation(string id, ContactPersonInformation contactPersonInformation)
        {
            if (id != contactPersonInformation.ContactID)
            {
                return BadRequest();
            }

            _context.Entry(contactPersonInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPersonInformationExists(id))
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

        // POST: api/ContactPersonInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateUsingSP(ContactPersonInformation contact)
        {
            var parameters = new[]
            {
                new SqlParameter("@ContactID", contact.ContactID ?? (object)DBNull.Value),
                new SqlParameter("@Name", contact.Name ?? (object)DBNull.Value),
                new SqlParameter("@Occupation", contact.Occupation ?? (object)DBNull.Value),
                new SqlParameter("@Relation", contact.Relation ?? (object)DBNull.Value),
                new SqlParameter("@Address", contact.Address ?? (object)DBNull.Value),
                new SqlParameter("@Phone", contact.Phone ?? (object)DBNull.Value),
                new SqlParameter("@EmployeeID", contact.EmployeeID ?? (object)DBNull.Value),
                new SqlParameter("@Flag", contact.Flag ?? (object)DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_ContactPersonInformation_Insert @ContactID, @Name, @Occupation, @Relation, @Address,@Phone, @EmployeeID,@Flag", parameters);
            return Ok("inserted");
        }

        // DELETE: api/ContactPersonInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactPersonInformation(string id)
        {
            var contactPersonInformation = await _context.ContactPersonInformations.FindAsync(id);
            if (contactPersonInformation == null)
            {
                return NotFound();
            }

            _context.ContactPersonInformations.Remove(contactPersonInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactPersonInformationExists(string id)
        {
            return _context.ContactPersonInformations.Any(e => e.ContactID == id);
        }
    }
}
