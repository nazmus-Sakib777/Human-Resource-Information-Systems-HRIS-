using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class Add_Building : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                            var proc1 = @" 
                                    CREATE PROCEDURE sp_AddBuilding 
                                    @BuildingID NVARCHAR(50), 
                                    @Floor NVARCHAR(50), 
                                    @RoomNumber NVARCHAR(50), 
                                    @Name NVARCHAR(50), 
                                    @CompanyID NVARCHAR(50) 
                                AS 
                                BEGIN 
                                    INSERT INTO Buildings (BuildingID, Floor, RoomNumber, Name, 
                CompanyID) 
                                    VALUES (@BuildingID, @Floor, @RoomNumber, @Name, @CompanyID) 
                                END 
 
                                ";
                            migrationBuilder.Sql(proc1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
