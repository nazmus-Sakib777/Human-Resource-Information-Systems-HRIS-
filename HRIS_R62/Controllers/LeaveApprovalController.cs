using HRIS_R62.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveApprovalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getLeaveApproval = await _context.LeaveApprovals.ToListAsync();
            return Ok(getLeaveApproval);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.LeaveApprovals.FindAsync(id);
            return Ok(result);
        }


        [HttpPost]
        //public async Task<IActionResult> Create([FromBody] LeaveApproval entity)
        //{
        //    var result = await _context.Database.ExecuteSqlAsync(
        //       "EXEC sp_InsertLeaveApprovals @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13" entity.LeaveApprovalID, entity.LeaveName, entity.LeaveFromDate, entity.LeaveToDate, entity.Remarks, entity.LocalAreaClerance, entity.LocalAreaRemarks, entity.ApprovedDate, entity.EntryUser, entity.LeaveEnjoyed, entity.TotalLeave, entity.LeaveYear, entity.ProvidedLeave, entity.EmployeeID
        //        );
        //    return Ok("Data Inserted Successfully!!");
        //}
        public async Task<IActionResult> Create([FromBody] LeaveApproval entity)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertLeaveApprovals @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13",
                entity.LeaveApprovalID, entity.LeaveName, entity.LeaveFromDate, entity.LeaveToDate, entity.Remarks, entity.LocalAreaClerance, entity.LocalAreaRemarks, entity.ApprovedDate, entity.EntryUser, entity.LeaveEnjoyed, entity.TotalLeave, entity.LeaveYear, entity.ProvidedLeave, entity.EmployeeID
            );

            return Ok("Data Inserted Successfully!!");
        }


        //---->EF POST
        //public async Task<IActionResult> Create([FromBody]LeaveApproval entity)
        //{
        //    LeaveApproval leaveApproval = new LeaveApproval();
        //    leaveApproval.LeaveApprovalID = entity.LeaveApprovalID;
        //    leaveApproval.LeaveName = entity.LeaveName;
        //    leaveApproval.LeaveFromDate = entity.LeaveFromDate;
        //    leaveApproval.LeaveToDate = entity.LeaveToDate;
        //    leaveApproval.Remarks = entity.Remarks;
        //    leaveApproval.LocalAreaClerance = entity.LocalAreaClerance;
        //    leaveApproval.LocalAreaRemarks = entity.LocalAreaRemarks;
        //    leaveApproval.ApprovedDate = entity.ApprovedDate;
        //    leaveApproval.EntryUser = entity.EntryUser;
        //    leaveApproval.LeaveEnjoyed = entity.LeaveEnjoyed;
        //    leaveApproval.TotalLeave = entity.TotalLeave;
        //    leaveApproval.LeaveYear = entity.LeaveYear;
        //    leaveApproval.ProvidedLeave = entity.ProvidedLeave;
        //    leaveApproval.EmployeeID = entity.EmployeeID;
        //    leaveApproval.EmployeeInformations = entity.EmployeeInformations;

        //    await _context.LeaveApprovals.AddAsync(leaveApproval);
        //    await _context.SaveChangesAsync();
        //    return Ok(entity);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LeaveApproval entity)
        {
            if (entity == null || id != entity.LeaveApprovalID)
            {
                return BadRequest("Invalid data or ID mismatch.");
            }

            var existingLeave = await _context.LeaveApprovals.FindAsync(id);

            if (existingLeave == null)
            {
                return NotFound($"LeaveApproval with ID = {id} not found.");
            }

            existingLeave.LeaveName = entity.LeaveName;
            existingLeave.LeaveFromDate = entity.LeaveFromDate;
            existingLeave.LeaveToDate = entity.LeaveToDate;
            existingLeave.Remarks = entity.Remarks;
            existingLeave.LocalAreaClerance = entity.LocalAreaClerance;
            existingLeave.LocalAreaRemarks = entity.LocalAreaRemarks;
            existingLeave.ApprovedDate = entity.ApprovedDate;
            existingLeave.EntryUser = entity.EntryUser;
            existingLeave.LeaveEnjoyed = entity.LeaveEnjoyed;
            existingLeave.TotalLeave = entity.TotalLeave;
            existingLeave.LeaveYear = entity.LeaveYear;
            existingLeave.ProvidedLeave = entity.ProvidedLeave;
            existingLeave.EmployeeID = entity.EmployeeID;
            existingLeave.EmployeeInformations = entity.EmployeeInformations;

            _context.LeaveApprovals.Update(existingLeave);
            await _context.SaveChangesAsync();

            return Ok("Updated Successfully");
        }

    }
}
