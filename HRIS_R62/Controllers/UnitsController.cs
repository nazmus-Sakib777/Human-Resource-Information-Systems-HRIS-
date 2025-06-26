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
    public class UnitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            return await _context.Units.ToListAsync();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(string id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            return unit;
        }
        //POST with SP
        [HttpPost("sp")]
        public IActionResult CreateSp(string uId, string uName, string cmpId)
        {
            Unit u = new Unit()
            {
                UnitID = uId,
                UnitName = uName,
                CompanyID = cmpId
            };
            this._context.InsertUnit(u);
            return Ok("Insert Successful");
        }
        // PUT: api/Units/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit(string id, Unit unit)
        {
            if (id != unit.UnitID)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        //// POST: api/Units

        //[HttpPost]
        //public async Task<ActionResult<Unit>> PostUnit(Unit unit)
        //{
        //    _context.Units.Add(unit);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UnitExists(unit.UnitID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetUnit", new { id = unit.UnitID }, unit);
        //}

        

        //// DELETE: api/Units/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUnit(string id)
        //{
        //    var unit = await _context.Units.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Units.Remove(unit);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UnitExists(string id)
        {
            return _context.Units.Any(e => e.UnitID == id);
        }
    }
}
