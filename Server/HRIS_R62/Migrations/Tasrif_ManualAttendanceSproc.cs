using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class ManualAttendanceSproc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE PROCEDURE InsertManualAttendance
            @ManualAttendanceID NVARCHAR(50),
            @AttendanceDate DATE,
            @AttendanceTime NVARCHAR(50),
            @EntryDate DATE,
            @Reason NVARCHAR(200),
            @LocalAreaClerance NVARCHAR(50),
            @LocalAreaRemarks NVARCHAR(200),
            @ApprovedDate DATE,
            @EntryUser NVARCHAR(100),
            @OutTime NVARCHAR(50),
            @Remarks NVARCHAR(200),
            @EmployeeID NVARCHAR(50)
	
        AS
        BEGIN
            SET NOCOUNT ON;

            INSERT INTO ManualAttendances(
                ManualAttendanceID,
                AttendanceDate,
                AttendanceTime,
                EntryDate,
                Reason,
                LocalAreaClerance,
                LocalAreaRemarks,
                ApprovedDate,
                EntryUser,
                OutTime,
                Remarks,
                EmployeeID
            )
            VALUES (
                @ManualAttendanceID,
                @AttendanceDate,
                @AttendanceTime,
                @EntryDate,
                @Reason,
                @LocalAreaClerance,
                @LocalAreaRemarks,
                @ApprovedDate,
                @EntryUser,
                @OutTime,
                @Remarks,
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
