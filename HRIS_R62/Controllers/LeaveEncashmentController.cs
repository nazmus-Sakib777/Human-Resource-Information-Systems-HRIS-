using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveEncashmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveEncashmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaveEncashment()
        {
            var getLeaveEncashment = await _context.LeaveEncashments.Include(x => x.LeaveEncashmentRates).ToListAsync();
            return Ok(getLeaveEncashment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.LeaveEncashments.Include(x => x.LeaveEncashmentRates).Where(x => x.LeaveEncashmentID == id).SingleOrDefaultAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveEncashment entity)
        {
            // Call stored procedure for LeaveEncashments
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertLeaveEncashment @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14", entity.LeaveEncashmentID, entity.EncashMonth, entity.EncashYear, entity.BasicSalary, entity.ActualDays, entity.ComputedDays, entity.LeaveEncashAmount, entity.OtherDeductions, entity.ActualEncashAmount, entity.ComputedEncashAmount, entity.LocalAreaClerance, entity.LocalAreaRemarks, entity.ApprovedDate, entity.LastMonthWorkingDays, entity.EmployeeID
             );
            foreach (var encashmentRate in entity.LeaveEncashmentRates)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_InsertLeaveEncashmentRates @p0, @p1, @p2, @p3",
                    encashmentRate.LeaveEncashmentRateID,
                    encashmentRate.ToGrossSalary,
                    encashmentRate.RateInPercent,
                    entity.LeaveEncashmentID
                );

            }
            return Ok("Data Saved Successfully!!");

        }
                //public async Task<IActionResult> Create([FromBody] LeaveEncashment entity)
                //{
                //    LeaveEncashment leaveEncashment = new LeaveEncashment();
                //    leaveEncashment.LeaveEncashmentID = entity.LeaveEncashmentID;
                //    leaveEncashment.EncashMonth = entity.EncashMonth;
                //    leaveEncashment.EncashYear = entity.EncashYear;
                //    leaveEncashment.BasicSalary = entity.BasicSalary;
                //    leaveEncashment.ActualDays = entity.ActualDays;
                //    leaveEncashment.ComputedDays = entity.ComputedDays;
                //    leaveEncashment.LeaveEncashAmount = entity.LeaveEncashAmount;
                //    leaveEncashment.OtherDeductions = entity.OtherDeductions;
                //    leaveEncashment.ActualEncashAmount = entity.ActualEncashAmount;
                //    leaveEncashment.ComputedEncashAmount = entity.ComputedEncashAmount;
                //    leaveEncashment.LocalAreaClerance = entity.LocalAreaClerance;
                //    leaveEncashment.LocalAreaRemarks = entity.LocalAreaRemarks;
                //    leaveEncashment.ApprovedDate = entity.ApprovedDate;
                //    leaveEncashment.LastMonthWorkingDays = entity.LastMonthWorkingDays;
                //    leaveEncashment.EmployeeID = entity.EmployeeID;
                //    await _context.LeaveEncashments.AddAsync(leaveEncashment);
                //    foreach(var encashmentRate in entity.LeaveEncashmentRates)
                //    {
                //        LeaveEncashmentRate leaveEncashmentRate = new LeaveEncashmentRate();
                //        leaveEncashmentRate.LeaveEncashmentRateID = encashmentRate.LeaveEncashmentRateID;
                //        leaveEncashmentRate.ToGrossSalary = encashmentRate.ToGrossSalary;
                //        leaveEncashmentRate.RateInPercent = encashmentRate.RateInPercent;
                //        leaveEncashmentRate.LeaveEncashmentID = leaveEncashment.LeaveEncashmentID;
                //        await _context.LeaveEncashmentRates.AddAsync(leaveEncashmentRate);
                //    }
                //    await _context.SaveChangesAsync();

                //    return Ok("Saved Successfully.");
                //}

                [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LeaveEncashment entity)
        {
            if (entity == null || id != entity.LeaveEncashmentID)
            {
                return BadRequest("Invalid data or ID mismatch.");
            }

            var existingEncashment = await _context.LeaveEncashments
                .Include(e => e.LeaveEncashmentRates)
                .FirstOrDefaultAsync(e => e.LeaveEncashmentID == id);

            if (existingEncashment == null)
            {
                return NotFound($"LeaveEncashment with ID = {id} not found.");
            }

            existingEncashment.EncashMonth = entity.EncashMonth;
            existingEncashment.EncashYear = entity.EncashYear;
            existingEncashment.BasicSalary = entity.BasicSalary;
            existingEncashment.ActualDays = entity.ActualDays;
            existingEncashment.ComputedDays = entity.ComputedDays;
            existingEncashment.LeaveEncashAmount = entity.LeaveEncashAmount;
            existingEncashment.OtherDeductions = entity.OtherDeductions;
            existingEncashment.ActualEncashAmount = entity.ActualEncashAmount;
            existingEncashment.ComputedEncashAmount = entity.ComputedEncashAmount;
            existingEncashment.LocalAreaClerance = entity.LocalAreaClerance;
            existingEncashment.LocalAreaRemarks = entity.LocalAreaRemarks;
            existingEncashment.ApprovedDate = entity.ApprovedDate;
            existingEncashment.LastMonthWorkingDays = entity.LastMonthWorkingDays;
            existingEncashment.EmployeeID = entity.EmployeeID;

            _context.LeaveEncashmentRates.RemoveRange(existingEncashment.LeaveEncashmentRates);

            foreach (var rate in entity.LeaveEncashmentRates)
            {
                LeaveEncashmentRate newRate = new LeaveEncashmentRate
                {
                    LeaveEncashmentRateID = rate.LeaveEncashmentRateID,
                    ToGrossSalary = rate.ToGrossSalary,
                    RateInPercent = rate.RateInPercent,
                    LeaveEncashmentID = existingEncashment.LeaveEncashmentID
                };
                await _context.LeaveEncashmentRates.AddAsync(newRate);
            }

            _context.LeaveEncashments.Update(existingEncashment);
            await _context.SaveChangesAsync();

            return Ok("Updated Successfully.");
        }

    }
}
