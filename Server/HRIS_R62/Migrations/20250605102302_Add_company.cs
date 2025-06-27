using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class Add_company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            


                 var proc1 = @"CREATE PROCEDURE sp_AddCompany 
                                        @CompanyID NVARCHAR(50), 
                                        @CompanyName NVARCHAR(50), 
                                        @CompanyShortName NVARCHAR(50), 
                                        @CompanyNameLocal NVARCHAR(50), 
                                        @CompanyAddress NVARCHAR(250), 
                                        @PhoneNumber NVARCHAR(50), 
                                        @FaxNumber NVARCHAR(50), 
                                        @Email NVARCHAR(50) 
                                    AS 
                                    BEGIN 
                                        INSERT INTO Companies ( 
                                            CompanyID, CompanyName, CompanyShortName, 
                                            CompanyNameLocal, CompanyAddress, 
                                            PhoneNumber, FaxNumber, Email 
                                        ) 
                                        VALUES ( 
                                            @CompanyID, @CompanyName, @CompanyShortName, 
                                            @CompanyNameLocal, @CompanyAddress, 
                                            @PhoneNumber, @FaxNumber, @Email 
                                        ) 
                                    END 
                                ";
                            migrationBuilder.Sql(proc1);

        } 
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP POCEDURE IF EXISTS sp_AddCompany");
        }
    }
}
