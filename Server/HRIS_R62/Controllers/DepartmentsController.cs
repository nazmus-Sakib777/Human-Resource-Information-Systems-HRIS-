using HRIS_R62.DTIOs_forSp;
using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _context.Departments
                //.Include(d => d.Company)
                .Select(d => new Department
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                    DepartmentShortName = d.DepartmentShortName,
                    DepartmentNameLocal = d.DepartmentNameLocal,
                    CompanyID = d.CompanyID,
                })
                .ToListAsync();

            return departments;
        }


        // GET: api/Departments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(string id)
        {
            var department = await _context.Departments
                                           .FirstOrDefaultAsync(d => d.DepartmentID == id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        //Rezaul Karim
        // POST: api/Departments
        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO dto)
        {
            var sql = "EXEC InsertDepartment @DepartmentID, @DepartmentName, @DepartmentShortName, @DepartmentNameLocal, @CompanyID";

            var parameters = new[]
            {
            new SqlParameter("@DepartmentID", dto.DepartmentID),
            new SqlParameter("@DepartmentName", dto.DepartmentName),
            new SqlParameter("@DepartmentShortName", dto.DepartmentShortName),
            new SqlParameter("@DepartmentNameLocal", dto.DepartmentNameLocal),
            new SqlParameter("@CompanyID", dto.CompanyID)
        };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return Ok(new { message = "Department inserted successfully." });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/Departments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(string id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departments.Any(d => d.DepartmentID == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
