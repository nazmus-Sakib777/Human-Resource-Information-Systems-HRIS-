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
    public class SectionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sections>>> GetSections()
        {
            return await _context.Sections.ToListAsync();
        }

        // GET: api/Sections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sections>> GetSections(string id)
        {
            var sections = await _context.Sections.FindAsync(id);

            if (sections == null)
            {
                return NotFound();
            }

            return sections;
        }
        //POST with SP
        [HttpPost("sp")]
        public IActionResult CreateSp(string secId, string secName, string secShortName, string seclocalName, string cmpId)
        {
            Sections sec = new Sections()
            {
                SectionsID = secId,
                SectionName = secName,
                SectionShortName = secShortName,
                SectionNameNative = seclocalName,
                CompanyID = cmpId
            };
            this._context.InsertSection(sec);
            return Ok("Insert Successful");
        }

        // PUT: api/Sections/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSections(string id, Sections sections)
        {
            if (id != sections.SectionsID)
            {
                return BadRequest();
            }

            _context.Entry(sections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionsExists(id))
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

        

        private bool SectionsExists(string id)
        {
            return _context.Sections.Any(e => e.SectionsID == id);
        }
    }
}
