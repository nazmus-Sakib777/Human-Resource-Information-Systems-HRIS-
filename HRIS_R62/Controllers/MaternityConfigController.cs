using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaternityConfigController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaternityConfigController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getMaternityConfig = await _context. MaternityConfigurations.ToListAsync();
            return Ok(getMaternityConfig);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.MaternityConfigurations.FindAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaternityConfiguration entity)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
                "Exec sp_InsertMaternityConfiguration @p0, @p1, @p2, @p3, @p4,  @p5, @p6, @p7,  @p8", entity.MaternityConfigurationID, entity.JoiningDate, entity.IsEligible, entity.LastWithdrawalDate, entity.InstallmentType, entity.NextWithdrawableTime, entity.CurrentWithdrawalDate,  entity.Status, entity.EmployeeID
                );
            return Ok("Data Inserted Successfully!!");
        }


        //---->EF POST
        //public async Task<IActionResult> Create([FromBody] MaternityConfiguration entity)
        //{
        //    MaternityConfiguration maternityConfiguration = new MaternityConfiguration();
        //    maternityConfiguration.MaternityConfigurationID = entity.MaternityConfigurationID;
        //    maternityConfiguration.JoiningDate = entity.JoiningDate;
        //    maternityConfiguration.IsEligible = entity.IsEligible;
        //    maternityConfiguration.LastWithdrawalDate = entity.LastWithdrawalDate;
        //    maternityConfiguration.InstallmentType = entity.InstallmentType;
        //    maternityConfiguration.NextWithdrawableTime = entity.NextWithdrawableTime;
        //    maternityConfiguration.CurrentWithdrawalDate = entity.CurrentWithdrawalDate;
        //    maternityConfiguration.GapInMonths = entity.GapInMonths;
        //    maternityConfiguration.Status = entity.Status;
        //    maternityConfiguration.EmployeeID = entity.EmployeeID;

        //    await _context.MaternityConfigurations.AddAsync(maternityConfiguration);
        //    await _context.SaveChangesAsync();

        //    return Ok(entity);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MaternityConfiguration entity)
        {
            if (entity == null || id != entity.MaternityConfigurationID)
            {
                return BadRequest("Invalid data or ID mismatch.");
            }

            var existingConfig = await _context.MaternityConfigurations.FindAsync(id);

            if (existingConfig == null)
            {
                return NotFound($"MaternityConfiguration with ID = {id} not found.");
            }

            existingConfig.MaternityConfigurationID = entity.MaternityConfigurationID;
            existingConfig.JoiningDate = entity.JoiningDate;
            existingConfig.IsEligible = entity.IsEligible;
            existingConfig.LastWithdrawalDate = entity.LastWithdrawalDate;
            existingConfig.InstallmentType = entity.InstallmentType;
            existingConfig.NextWithdrawableTime = entity.NextWithdrawableTime;
            existingConfig.CurrentWithdrawalDate = entity.CurrentWithdrawalDate;
            existingConfig.GapInMonths = entity.GapInMonths;
            existingConfig.Status = entity.Status;
            existingConfig.EmployeeID = entity.EmployeeID;

            _context.MaternityConfigurations.Update(existingConfig);
            await _context.SaveChangesAsync();

            return Ok ("Updated Successfully");
        }

    }
}
