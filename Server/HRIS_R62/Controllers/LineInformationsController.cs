using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS_R62.Models;
using System.ComponentModel.Design;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineInformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LineInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LineInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineInformation>>> GetLineInformations()
        {
            return await _context.LineInformations.ToListAsync();
        }

        // GET: api/LineInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineInformation>> GetLineInformation(string id)
        {
            var lineInformation = await _context.LineInformations.FindAsync(id);

            if (lineInformation == null)
            {
                return NotFound();
            }

            return lineInformation;
        }

        // PUT: api/LineInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineInformation(string id, LineInformation lineInformation)
        {
            if (id != lineInformation.LineID)
            {
                return BadRequest();
            }

            _context.Entry(lineInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineInformationExists(id))
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

        //Post with sp

        [HttpPost("SP_Insert")]/* -- store proc Call*/
        public IActionResult InsertLineInformations(string LineID, string LineName, DateTime EntryDate,string UnitID,string BuildingID, string SectionsID,string CompanyID, string DivisionID)
        {
           LineInformation LI = new LineInformation()
            {
                       LineID = LineID,
                        LineName = LineName,
                        EntryDate = EntryDate,
                        UnitID = UnitID,
                        BuildingID = BuildingID,
                        SectionsID = SectionsID,
                        CompanyID = CompanyID,
                        DivisionID = DivisionID
            };
            this._context.InsertLineInformations(LI);
            return Ok("Insert Successful");
        }






        // POST: api/LineInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LineInformation>> PostLineInformation(LineInformation lineInformation)
        {
            _context.LineInformations.Add(lineInformation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineInformationExists(lineInformation.LineID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLineInformation", new { id = lineInformation.LineID }, lineInformation);
        }

        //// DELETE: api/LineInformations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLineInformation(string id)
        //{
        //    var lineInformation = await _context.LineInformations.FindAsync(id);
        //    if (lineInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.LineInformations.Remove(lineInformation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool LineInformationExists(string id)
        {
            return _context.LineInformations.Any(e => e.LineID == id);
        }
    }
}
