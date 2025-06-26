using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertMaternitybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROC sp_InsertMaternitybill
					@MaternityBillID NVARCHAR(50),
					@MaternityConfigurationID NVARCHAR(50) = NULL,
					@CurrentMonth DATE = '',
					@FromMonth DATE = '',
					@ToMonth DATE = '',
					@NumberOfMonths INT = 0,
					@BasicSalary DECIMAL(10,2) = 0.00,
					@WorkingDays INT = 0,
					@ActualCurrentSalary DECIMAL(10,2) = 0.00,
					@EarnedLeaveDays DECIMAL(10,4) = 0.00,
					@EarnedLeaveAmount DECIMAL(18,2) = 0.00,
					@Computed3MonthNetPayable DECIMAL(10,4) = 0.00,
					@Computed3MonthWorkingDays INT = 0,
					@ActualPay  DECIMAL(10,4),
					@ComputedPay DECIMAL(10,4),
					@ActualNetPayable  DECIMAL(10,4),
					@ComputedNetPayable DECIMAL(10,4),
					@LocalAreaClerance NVARCHAR(50),
					@LocalAreaRemarks NVARCHAR(100),
					@ApprovedDate DATE,
					@EntryDate DATE,
					@EmployeeID NVARCHAR(50) = NULL
				AS
				BEGIN
					INSERT INTO MaternityBills (
						MaternityBillID, MaternityConfigurationID, CurrentMonth, FromMonth, ToMonth, NumberOfMonths, BasicSalary, WorkingDays, ActualCurrentSalary, EarnedLeaveDays, EarnedLeaveAmount, Computed3MonthNetPayable, Computed3MonthWorkingDays, ActualPay, ComputedPay, ActualNetPayable, ComputedNetPayable, LocalAreaClerance, LocalAreaRemarks, ApprovedDate, EntryDate, EmployeeID	
					)
					VALUES(
						@MaternityBillID, @MaternityConfigurationID, @CurrentMonth, @FromMonth, @ToMonth, @NumberOfMonths, @BasicSalary, @WorkingDays,			@ActualCurrentSalary,	@EarnedLeaveDays, @EarnedLeaveAmount, @Computed3MonthNetPayable, @Computed3MonthWorkingDays, @ActualPay,		@ComputedPay,	@ActualNetPayable,  @ComputedNetPayable, @LocalAreaClerance, @LocalAreaRemarks, @ApprovedDate, @EntryDate, @EmployeeID	
					)
				END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS sp_InsertMaternitybill");
        }
    }
}
