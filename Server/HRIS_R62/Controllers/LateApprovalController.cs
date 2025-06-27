using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LateApprovalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LateApprovalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LateApproval
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LateApproval>>> GetLateApprovals()
        {
            return await _context.LateApprovals
                                 .Include(l => l.EmployeeInformation)
                                 .ToListAsync();
        }

        // GET: api/LateApproval/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LateApproval>> GetLateApproval(string id)
        {
            var lateApproval = await _context.LateApprovals
                                             .Include(l => l.EmployeeInformation)
                                             .FirstOrDefaultAsync(l => l.LateApprovalID == id);

            if (lateApproval == null)
                return NotFound();

            return lateApproval;
        }

        // POST: api/LateApproval

        [HttpPost("sp")]
        public IActionResult CreateSp(string id, DateTime ldate, string ltime,DateTime ledate,string lreason,string lareaclearence,string larearemarks,DateTime appdate,string euser,string empId)
        {
            LateApproval sh = new LateApproval()
            {
                LateApprovalID = id,
                LateDate = ldate,
                LateTime = ltime,
                LateEntryDate = ledate,
                LateReason = lreason,
                LocalAreaClerance = lareaclearence,
                LocalAreaRemarks = larearemarks,
                ApprovedDate = appdate,
                EntryUser = euser,
                EmployeeID = empId


            };
            this._context.InsertLateApp(sh);
            return Ok("Insert Successful");
        }

        //



        [HttpPost]
        public async Task<ActionResult<LateApproval>> PostLateApproval(LateApproval lateApproval)
        {
            _context.LateApprovals.Add(lateApproval);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLateApproval), new { id = lateApproval.LateApprovalID }, lateApproval);
        }

        // PUT: api/LateApproval/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLateApproval(string id, LateApproval lateApproval)
        {
            if (id != lateApproval.LateApprovalID)
                return BadRequest("ID mismatch");

            _context.Entry(lateApproval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LateApprovalExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/LateApproval/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLateApproval(string id)
        {
            var lateApproval = await _context.LateApprovals.FindAsync(id);
            if (lateApproval == null)
                return NotFound();

            _context.LateApprovals.Remove(lateApproval);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LateApprovalExists(string id)
        {
            return _context.LateApprovals.Any(e => e.LateApprovalID == id);
        }
    }
}
