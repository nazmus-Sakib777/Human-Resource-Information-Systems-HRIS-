using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE PROCEDURE InsertAttendanceStatuss
                @AttendanceStatusID NVARCHAR(50),
                @StatusName NVARCHAR(100),
                @StatusShortName NVARCHAR(20)

	
	
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO AttendanceStatuss(AttendanceStatusID, StatusName, StatusShortName)
                VALUES (@AttendanceStatusID, @StatusName, @StatusShortName);
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
