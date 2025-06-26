using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getLeaveRecord = await _context.LeaveRecords.ToListAsync();
            return Ok(getLeaveRecord);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.LeaveRecords.FindAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveRecord entity)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertLeaveRecords @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12", entity.LeaveRecordID, entity.LeaveYear, entity.LeaveDate, entity.LeaveTime, entity.EntryDate, entity.Reason, entity.DeliveryDate, entity.LeaveType, entity.TotalLeave, entity.LeaveEnjoyed, entity.ApprovedDate, entity.EntryUser, entity.EmployeeID);
            return Ok("Data Inserted Successfully!!");
        }

        //public async Task<IActionResult> Create([FromBody]LeaveRecord entity)
        //{
        //    LeaveRecord leaveRecord = new LeaveRecord();
        //    leaveRecord.LeaveRecordID = entity.LeaveRecordID;
        //    leaveRecord.LeaveYear = entity.LeaveYear;
        //    leaveRecord.LeaveDate = entity.LeaveDate;
        //    leaveRecord.LeaveTime = entity.LeaveTime;
        //    leaveRecord.EntryDate = entity.EntryDate;
        //    leaveRecord.Reason = entity.Reason;
        //    leaveRecord.DeliveryDate = entity.DeliveryDate;
        //    leaveRecord.LeaveType = entity.LeaveType;
        //    leaveRecord.TotalLeave = entity.TotalLeave;
        //    leaveRecord.LeaveEnjoyed = entity.LeaveEnjoyed;
        //    leaveRecord.ApprovedDate = entity.ApprovedDate;
        //    leaveRecord.EntryUser = entity.EntryUser;
        //    leaveRecord.EmployeeID = entity.EmployeeID;
        //    leaveRecord.EmployeeInformation = entity.EmployeeInformation;

        //    await _context.LeaveRecords.AddAsync(leaveRecord);
        //    await _context.SaveChangesAsync();
        //    return Ok(entity);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LeaveRecord entity)
        {
            if (entity == null || id != entity.LeaveRecordID)
            {
                return BadRequest("Invalid data or ID mismatch.");
            }

            var existingRecord = await _context.LeaveRecords.FindAsync(id);

            if (existingRecord == null)
            {
                return NotFound($"LeaveRecord with ID = {id} not found.");
            }

        
            existingRecord.LeaveYear = entity.LeaveYear;
            existingRecord.LeaveDate = entity.LeaveDate;
            existingRecord.LeaveTime = entity.LeaveTime;
            existingRecord.EntryDate = entity.EntryDate;
            existingRecord.Reason = entity.Reason;
            existingRecord.DeliveryDate = entity.DeliveryDate;
            existingRecord.LeaveType = entity.LeaveType;
            existingRecord.TotalLeave = entity.TotalLeave;
            existingRecord.LeaveEnjoyed = entity.LeaveEnjoyed;
            existingRecord.ApprovedDate = entity.ApprovedDate;
            existingRecord.EntryUser = entity.EntryUser;
            existingRecord.EmployeeID = entity.EmployeeID;
            existingRecord.EmployeeInformation = entity.EmployeeInformation;

            _context.LeaveRecords.Update(existingRecord);
            await _context.SaveChangesAsync();

            return Ok("Updated Successfully");
        }

    }
}
