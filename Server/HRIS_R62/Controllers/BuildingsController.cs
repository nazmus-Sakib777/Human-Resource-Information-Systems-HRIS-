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
    public class BuildingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(string id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        // PUT: api/Buildings/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(string id, Building building)
        {
            if (id != building.BuildingID)
            {
                return BadRequest();
            }

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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

        // POST: api/Buildings
        [HttpPost("add")]

        public IActionResult InsertBuilding(string BuildingID, string Floor, string
        RoomNumber, string Name, string CompanyID)
        {
            Building bui = new Building()
            {
                BuildingID = BuildingID,
                Floor = Floor,
                RoomNumber = RoomNumber,
                Name = Name,
                CompanyID = CompanyID
            };
            this._context.AddBuildingUsingSP(bui);
            return Ok("Insert Successful");
        }

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(string id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingExists(string id)
        {
            return _context.Buildings.Any(e => e.BuildingID == id);
        }
    }
}
