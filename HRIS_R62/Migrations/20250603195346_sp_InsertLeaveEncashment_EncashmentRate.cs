using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertLeaveEncashment_EncashmentRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROC sp_InsertLeaveEncashment
					@LeaveEncashmentID NVARCHAR(50),
					@EncashMonth NVARCHAR(10),
					@EncashYear NVARCHAR(4),
					@BasicSalary DECIMAL(18,0),
					@ActualDays NVARCHAR(4),
					@ComputedDays NVARCHAR(50),
					@LeaveEncashAmount DECIMAL(18,0),
					@OtherDeductions DECIMAL(18,0),
					@ActualEncashAmount DECIMAL(18,0),
					@ComputedEncashAmount DECIMAL(18,0),
					@LocalAreaClerance NVARCHAR(50),
					@LocalAreaRemarks NVARCHAR(150),
					@ApprovedDate DATE,
					@LastMonthWorkingDays INT,
					@EmployeeID NVARCHAR(50)
				AS
				BEGIN
					INSERT INTO LeaveEncashments(
						LeaveEncashmentID, EncashMonth, EncashYear, BasicSalary, ActualDays, ComputedDays, LeaveEncashAmount, OtherDeductions,		ActualEncashAmount,  	ComputedEncashAmount, LocalAreaClerance, LocalAreaRemarks, ApprovedDate, LastMonthWorkingDays,	EmployeeID
					)
					VALUES(
						@LeaveEncashmentID, @EncashMonth, @EncashYear, @BasicSalary, @ActualDays, @ComputedDays, @LeaveEncashAmount, @OtherDeductions,				@ActualEncashAmount, @ComputedEncashAmount, @LocalAreaClerance, @LocalAreaRemarks, @ApprovedDate, @LastMonthWorkingDays,	 @EmployeeID
					)
				END;
           ");

			migrationBuilder.Sql(@"
				CREATE PROC sp_InsertLeaveEncashmentRates
					@LeaveEncashmentRateID NVARCHAR(50),
					@ToGrossSalary NUMERIC(18,0),
					@RateInPercent NUMERIC(18,0),
					@LeaveEncashmentID NVARCHAR(50)
				AS
				BEGIN
					INSERT INTO LeaveEncashmentRates(
						LeaveEncashmentRateID, ToGrossSalary, RateInPercent, LeaveEncashmentID
					)
					VALUES(
						@LeaveEncashmentRateID, @ToGrossSalary, @RateInPercent, @LeaveEncashmentID
					)
				END;
		   ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP POCEDURE IF EXISTS sp_InsertLeaveEncashment");
            migrationBuilder.Sql(@"DROP POCEDURE IF EXISTS sp_InsertLeaveEncashment");
        }
    }
}
