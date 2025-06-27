using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE PROCEDURE spGetEmployeeAttendanceABC
                            @StartDate DATETIME = NULL,
                            @EndDate DATETIME = NULL,
                            @SpecificDate DATETIME = NULL,
                            @DivisionId  NVARCHAR(50) = NULL,
                            @DepartmentId  NVARCHAR(50) = NULL,
                            @UnitId NVARCHAR(50) = NULL,
                            @SectionsID  NVARCHAR(50) = NULL,
                            @LineId  NVARCHAR(50) = NULL,
                            @EmployeeID NVARCHAR(50) = NULL
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            BEGIN TRY
                                BEGIN TRANSACTION;

                                SELECT 
                                    ei.EmployeeId,
                                    ei.EmployeeName,
                                    u.UnitName,
                                    d.DivisionName,
                                    dept.DepartmentName,
                                    s.SectionName,
                                    li.LineName,
                                    pr.RecordDate,
                                    pr.InTime,
                                    pr.OutTime,
            
                                    CASE 
                                        WHEN pr.InTime IS NOT NULL AND pr.OutTime IS NOT NULL THEN 'Present'
                                        ELSE 'Absent'
                                    END AS PresentStatus
                                FROM EmployeeInformations ei
                                LEFT JOIN ProximityRecords pr 
                                    ON pr.EmployeeId = ei.EmployeeId 
                                    AND (
                                        (@SpecificDate IS NOT NULL AND pr.RecordDate = @SpecificDate) OR
                                        (@SpecificDate IS NULL AND pr.RecordDate BETWEEN @StartDate AND @EndDate)
                                    )
                                LEFT JOIN Units u ON ei.UnitId = u.UnitId
                                LEFT JOIN Divisions d ON ei.DivisionId = d.DivisionId
                                LEFT JOIN Departments dept ON ei.DepartmentId = dept.DepartmentId
                                LEFT JOIN Sections s ON ei.SectionId = s.SectionsID
                                LEFT JOIN LineInformations li ON ei.LineId = li.LineId
                                WHERE 
                                    (@EmployeeID IS NULL OR ei.EmployeeId = @EmployeeID)
                                    AND (@UnitId IS NULL OR ei.UnitId = @UnitId)
                                    AND (@DivisionId IS NULL OR ei.DivisionId = @DivisionId)
                                    AND (@DepartmentId IS NULL OR ei.DepartmentId = @DepartmentId)
                                    AND (@SectionsID IS NULL OR ei.SectionId = @SectionsID)
                                    AND (@LineId IS NULL OR ei.LineId = @LineId)
                                ORDER BY 
                                    ei.EmployeeId,
                                    pr.RecordDate;

                                COMMIT TRANSACTION;
                            END TRY
                            BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                    ROLLBACK TRANSACTION;

                                DECLARE @ErrorMessage NVARCHAR(4000);
                                SET @ErrorMessage = ERROR_MESSAGE();
                                RAISERROR (@ErrorMessage, 16, 1);
                            END CATCH
                        END;
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
