using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class ScriptTASU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
               CREATE PROCEDURE InsertEarlyLeaveInformations
                @EarlyLeaveInformationID VARCHAR(50),
                @LeaveDate DATE,
                @LeaveType VARCHAR(50),
                @LeaveTime time,
                @EmployeeID VARCHAR(50)

                AS
                BEGIN
                    INSERT INTO EarlyLeaveInformation (
                        EarlyLeaveInformationID, LeaveDate, LeaveType, LeaveTime, EmployeeID
                    )
                    VALUES (
                        @EarlyLeaveInformationID, @LeaveDate, @LeaveType, @LeaveTime, @EmployeeID
                    )
                END
                GO
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
