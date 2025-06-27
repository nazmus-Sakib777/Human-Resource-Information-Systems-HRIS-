using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertLeaveApprovals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				CREATE PROC sp_InsertLeaveApprovals
					@LeaveApprovalID NVARCHAR(50),
					@LeaveName NVARCHAR(30),
					@LeaveFromDate DATETIME,
					@LeaveToDate DATETIME,
					@Remarks NVARCHAR(150),
					@LocalAreaClerance NVARCHAR(50),
					@LocalAreaRemarks NVARCHAR(150),
					@ApprovedDate DATETIME = '',
					@EntryUser NVARCHAR(50),
					@LeaveEnjoyed NVARCHAR(8),
					@TotalLeave NVARCHAR(4),
					@LeaveYear NVARCHAR(4),
					@ProvidedLeave NVARCHAR(4),
					@EmployeeID NVARCHAR(MAX),
					@EmployeeInformationsEmployeeID NVARCHAR(50) = NULL
				AS
				BEGIN
					INSERT INTO LeaveApprovals(
						LeaveApprovalID, LeaveName, LeaveFromDate, LeaveToDate, Remarks, LocalAreaClerance, LocalAreaRemarks, ApprovedDate, EntryUser,	LeaveEnjoyed,			TotalLeave, LeaveYear, ProvidedLeave, EmployeeID, EmployeeInformationsEmployeeID
					 )
				
					VALUES(
						@LeaveApprovalID, @LeaveName, @LeaveFromDate, @LeaveToDate, @Remarks, @LocalAreaClerance, @LocalAreaRemarks, @ApprovedDate,@EntryUser, 				@LeaveEnjoyed,	@TotalLeave, @LeaveYear, @ProvidedLeave, @EmployeeID, @EmployeeInformationsEmployeeID
					)
				END;
           ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS sp_InsertLeaveApprovals");
        }
    }
}
