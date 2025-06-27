using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertLeaveRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROC sp_InsertLeaveRecords
					@LeaveRecordID NVARCHAR(50),
					@LeaveYear NVARCHAR(4),
					@LeaveDate DATE,
					@LeaveTime NVARCHAR(12),
					@EntryDate DATE,
					@Reason NVARCHAR(150),
					@DeliveryDate DATE,
					@LeaveType NVARCHAR(30),
					@TotalLeave NVARCHAR(4),
					@LeaveEnjoyed NVARCHAR(4),
					@ApprovedDate DATE,
					@EntryUser NVARCHAR(50),
					@EmployeeID NVARCHAR(50)
				AS
				BEGIN
					INSERT INTO LeaveRecords(
						LeaveRecordID, LeaveYear, LeaveDate, LeaveTime, EntryDate, Reason, DeliveryDate, LeaveType, TotalLeave, LeaveEnjoyed,	ApprovedDate, EntryUser, EmployeeID
					  )
					VALUES(
						@LeaveRecordID, @LeaveYear, @LeaveDate, @LeaveTime, @EntryDate, @Reason, @DeliveryDate, @LeaveType, @TotalLeave, @LeaveEnjoyed, @ApprovedDate, @EntryUser, @EmployeeID
					)
				END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS sp_InsertLeaveRecords");
        }
    }
}
