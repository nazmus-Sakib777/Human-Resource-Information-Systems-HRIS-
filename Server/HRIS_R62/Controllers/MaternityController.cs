using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaternityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaternityController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getMaternity = await _context.MaternityBills.ToListAsync();
            return Ok(getMaternity);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.MaternityBills.FindAsync(id);
            return Ok(result);
        }


        #region Create
        [HttpPost("Create")]
        #region EF
        //public async Task<IActionResult> Create([FromBody] MaternityBill entity)
        //{
        //    MaternityBill maternityBill = new MaternityBill();
        //    maternityBill.MaternityBillID = entity.MaternityBillID;
        //    maternityBill.MaternityConfigurationID = entity.MaternityConfigurationID;
        //    maternityBill.CurrentMonth = entity.CurrentMonth;
        //    maternityBill.FromMonth = entity.FromMonth;
        //    maternityBill.ToMonth = entity.ToMonth;
        //    maternityBill.NumberOfMonths = entity.NumberOfMonths;
        //    maternityBill.BasicSalary = entity.BasicSalary;
        //    maternityBill.WorkingDays = entity.WorkingDays;
        //    maternityBill.ActualCurrentSalary = entity.ActualCurrentSalary;
        //    maternityBill.EarnedLeaveDays = entity.EarnedLeaveDays;
        //    maternityBill.EarnedLeaveAmount = entity.EarnedLeaveAmount;
        //    maternityBill.Computed3MonthNetPayable = entity.Computed3MonthNetPayable;
        //    maternityBill.Computed3MonthWorkingDays = entity.Computed3MonthWorkingDays;
        //    maternityBill.ActualPay = entity.ActualPay;
        //    maternityBill.ComputedPay = entity.ComputedPay;
        //    maternityBill.ActualNetPayable = entity.ActualNetPayable;
        //    maternityBill.ComputedNetPayable = entity.ActualNetPayable;
        //    maternityBill.LocalAreaClerance = entity.LocalAreaClerance;
        //    maternityBill.LocalAreaRemarks = entity.LocalAreaRemarks;
        //    maternityBill.ApprovedDate = entity.ApprovedDate;
        //    maternityBill.EntryDate = entity.EntryDate;
        //    maternityBill.MaternityConfiguration = entity.MaternityConfiguration;
        //    maternityBill.EmployeeID = entity.EmployeeID;

        //    await _context.MaternityBills.AddAsync(maternityBill);
        //    await _context.SaveChangesAsync();
        //    return Ok(entity);
        //}
        #endregion
        #region Procedure
        #region Procedure
        public async Task<IActionResult> Create([FromBody] MaternityBill entity)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
                   "EXEC sp_InsertMaternitybill @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, @p21", entity.MaternityBillID, entity.MaternityConfigurationID, entity.CurrentMonth, entity.FromMonth, entity.ToMonth, entity.NumberOfMonths, entity.BasicSalary, entity.WorkingDays, entity.ActualCurrentSalary, entity.EarnedLeaveDays, entity.EarnedLeaveAmount, entity.Computed3MonthNetPayable, entity.Computed3MonthWorkingDays, entity.ActualPay, entity.ComputedPay, entity.ActualNetPayable, entity.ComputedNetPayable, entity.LocalAreaClerance, entity.LocalAreaRemarks, entity.ApprovedDate, entity.EntryDate, entity.EmployeeID
                );
            return Ok(result);
        }
        #endregion
        #endregion

        #endregion

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MaternityBill entity)
        {
            if (entity == null || id != entity.MaternityBillID)
            {
                return BadRequest("Invalid data or ID mismatch.");
            }

            var existingBill = await _context.MaternityBills.FindAsync(id);

            if (existingBill == null)
            {
                return NotFound($"MaternityBill with ID = {id} not found.");
            }

            existingBill.MaternityConfigurationID = entity.MaternityConfigurationID;
            existingBill.CurrentMonth = entity.CurrentMonth;
            existingBill.FromMonth = entity.FromMonth;
            existingBill.ToMonth = entity.ToMonth;
            existingBill.NumberOfMonths = entity.NumberOfMonths;
            existingBill.BasicSalary = entity.BasicSalary;
            existingBill.WorkingDays = entity.WorkingDays;
            existingBill.ActualCurrentSalary = entity.ActualCurrentSalary;
            existingBill.EarnedLeaveDays = entity.EarnedLeaveDays;
            existingBill.EarnedLeaveAmount = entity.EarnedLeaveAmount;
            existingBill.Computed3MonthNetPayable = entity.Computed3MonthNetPayable;
            existingBill.Computed3MonthWorkingDays = entity.Computed3MonthWorkingDays;
            existingBill.ActualPay = entity.ActualPay;
            existingBill.ComputedPay = entity.ComputedPay;
            existingBill.ActualNetPayable = entity.ActualNetPayable;
            existingBill.ComputedNetPayable = entity.ComputedNetPayable; 
            existingBill.LocalAreaClerance = entity.LocalAreaClerance;
            existingBill.LocalAreaRemarks = entity.LocalAreaRemarks;
            existingBill.ApprovedDate = entity.ApprovedDate;
            existingBill.EntryDate = entity.EntryDate;
            existingBill.MaternityConfiguration = entity.MaternityConfiguration;
            existingBill.EmployeeID = entity.EmployeeID;

            _context.MaternityBills.Update(existingBill);
            await _context.SaveChangesAsync();

            return Ok("Updated Successfully");
        }

    }
}
