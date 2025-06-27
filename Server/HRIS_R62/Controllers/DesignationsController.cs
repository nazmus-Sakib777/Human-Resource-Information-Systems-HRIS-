using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Designations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignations()
        {
            return await _context.Designations.ToListAsync();
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetDesignation(string id)
        {
            var designation = await _context.Designations.FindAsync(id);

            if (designation == null)
            {
                return NotFound();
            }

            return designation;
        }

        //// PUT: api/Designations/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignation(string id, Designation designation)
        {
            if (id != designation.DesignationID)
            {
                return BadRequest();
            }

            _context.Entry(designation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(id))
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
        public IActionResult InsertDesignation(string DesignationID, string DesignationName, string DesignationNameLocal)
        {
            Designation des = new Designation()
            {
                DesignationID = DesignationID,
                DesignationName = DesignationName,
                DesignationNameLocal = DesignationNameLocal
            };
            this._context.InsertDesignation(des);
            return Ok("Insert Successful");
        }



        private bool DesignationExists(string id)
        {
            return _context.Designations.Any(e => e.DesignationID == id);
        }
    }
}
