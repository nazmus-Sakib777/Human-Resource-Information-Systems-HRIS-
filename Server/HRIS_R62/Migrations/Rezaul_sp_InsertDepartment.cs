using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class sp_InsertDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE InsertDepartment
                    @DepartmentID NVARCHAR(50),
                    @DepartmentName NVARCHAR(50),
                    @DepartmentShortName NVARCHAR(50),
                    @DepartmentNameLocal NVARCHAR(50),
                    @CompanyID NVARCHAR(50)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF NOT EXISTS (SELECT 1 FROM Companies WHERE CompanyID = @CompanyID)
                    BEGIN
                        RAISERROR('Invalid CompanyID: Company does not exist.', 16, 1);
                        RETURN;
                    END

                    INSERT INTO Departments(
                        DepartmentID,
                        DepartmentName,
                        DepartmentShortName,
                        DepartmentNameLocal,
                        CompanyID
                    )
                    VALUES (
                        @DepartmentID,
                        @DepartmentName,
                        @DepartmentShortName,
                        @DepartmentNameLocal,
                        @CompanyID
                    );
                END;"
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS sp_InsertDepartment");
        }
    }
}
