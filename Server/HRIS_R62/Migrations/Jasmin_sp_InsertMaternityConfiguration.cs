using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertMaternityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROC sp_InsertMaternityConfiguration
                	@MaternityConfigurationID NVARCHAR(50),
                	@JoiningDate DATE = '',
                	@IsEligible BIT ,
                	@LastWithdrawalDate DATE ='',
                	@InstallmentType NVARCHAR(20),
                	@NextWithdrawableTime INT = 0,
                	@CurrentWithdrawalDate DATE ='',
                	@Status NVARCHAR(MAX) ,
                	@EmployeeID NVARCHAR(50)
                
                AS
                BEGIN
                	INSERT INTO MaternityConfigurations (
                		MaternityConfigurationID, JoiningDate, IsEligible, LastWithdrawalDate, InstallmentType, NextWithdrawableTime, CurrentWithdrawalDate,        Status,        EmployeeID
                	)
                	VALUES(
                		@MaternityConfigurationID, @JoiningDate, @IsEligible, @LastWithdrawalDate, @InstallmentType, @NextWithdrawableTime,         @CurrentWithdrawalDate,         @Status, @EmployeeID
                	)
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP POCEDURE IF EXISTE sp_InsertMaternityConfiguration");
        }
    }
}
