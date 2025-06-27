using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class lateapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE PROCEDURE InsertLateApproval
    @LateApprovalID NVARCHAR(50),
    @LateDate DATE,
    @LateTime NVARCHAR(50),
    @LateEntryDate DATE,
    @LateReason NVARCHAR(200),
    @LocalAreaClerance NVARCHAR(50),
    @LocalAreaRemarks NVARCHAR(200),
    @ApprovedDate DATE,
    @EntryUser NVARCHAR(100),
    @EmployeeID NVARCHAR(50)
	
	
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO LateApprovals(
        LateApprovalID,
        LateDate,
        LateTime,
        LateEntryDate,
        LateReason,
        LocalAreaClerance,
        LocalAreaRemarks,
        ApprovedDate,
        EntryUser,
        EmployeeID
    )
    VALUES (
        @LateApprovalID,
        @LateDate,
        @LateTime,
        @LateEntryDate,
        @LateReason,
        @LocalAreaClerance,
        @LocalAreaRemarks,
        @ApprovedDate,
        @EntryUser,
        @EmployeeID
    );
END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
