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
    public class DivisionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Divisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> GetDivisions()
        {
            return await _context.Divisions.ToListAsync();
        }

        // GET: api/Divisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> GetDivision(string id)
        {
            var division = await _context.Divisions.FindAsync(id);

            if (division == null)
            {
                return NotFound();
            }

            return division;
        }

        // PUT: api/Divisions/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivision(string id, Division division)
        {
            if (id != division.DivisionID)
            {
                return BadRequest();
            }

            _context.Entry(division).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisionExists(id))
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


        //POST with SP
        [HttpPost("sp")]
        public IActionResult CreateSp(string divId, string divName, string DivShortName, string divlocalName)
        {
            Division div = new Division()
            {
                DivisionID = divId,
                DivisionName = divName,
                DivisionShortName = DivShortName,
                DivisionNameLocal = divlocalName
            };
            this._context.InsertDivision(div);
            return Ok("Insert Successful");
        }




        private bool DivisionExists(string id)
        {
            return _context.Divisions.Any(e => e.DivisionID == id);
        }

        //// DELETE: api/Divisions/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDivision(string id)
        //{
        //    var division = await _context.Divisions.FindAsync(id);
        //    if (division == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Divisions.Remove(division);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}
