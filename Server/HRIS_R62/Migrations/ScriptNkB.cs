using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class ScriptNkB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceConfigurations",
                columns: table => new
                {
                    AttendanceConfigurationID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraceTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchBreakStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    LunchBreakEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EveningSnacksBreakStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EveningSnacksBreakEndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceConfigurations", x => x.AttendanceConfigurationID);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceStatuss",
                columns: table => new
                {
                    AttendanceStatusID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStatuss", x => x.AttendanceStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyNameLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DesignationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DesignationNameLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DivisionShortName = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    DivisionNameLocal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmploymentTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.EmploymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GradeShortID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromGrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToGrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Medical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConveyanceAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "LogFiles",
                columns: table => new
                {
                    LogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFiles", x => x.LogID);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                    table.ForeignKey(
                        name: "FK_Buildings_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentNameLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionsID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SectionShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SectionNameNative = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionsID);
                    table.ForeignKey(
                        name: "FK_Sections_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                    table.ForeignKey(
                        name: "FK_Units_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "TiffinAllowanceRates",
                columns: table => new
                {
                    TiffinAllowanceRateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RateInTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DesignationID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiffinAllowanceRates", x => x.TiffinAllowanceRateID);
                    table.ForeignKey(
                        name: "FK_TiffinAllowanceRates_Designations_DesignationID",
                        column: x => x.DesignationID,
                        principalTable: "Designations",
                        principalColumn: "DesignationID");
                });

            migrationBuilder.CreateTable(
                name: "NightAllowances",
                columns: table => new
                {
                    NightAllowanceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryMinimum = table.Column<decimal>(type: "money", nullable: false),
                    SalaryMaximum = table.Column<decimal>(type: "money", nullable: false),
                    NightAllowanceRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NightAllowances", x => x.NightAllowanceID);
                    table.ForeignKey(
                        name: "FK_NightAllowances_EmploymentTypes_EmploymentTypeID",
                        column: x => x.EmploymentTypeID,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NightAllowanceTimes",
                columns: table => new
                {
                    NightAllowanceTimeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NightHours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NightMinutes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NightAllowanceTimes", x => x.NightAllowanceTimeID);
                    table.ForeignKey(
                        name: "FK_NightAllowanceTimes_EmploymentTypes_EmploymentTypeID",
                        column: x => x.EmploymentTypeID,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiffinAllowanceTimes",
                columns: table => new
                {
                    TiffinAllowanceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AllowanceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AllowanceType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiffinAllowanceTimes", x => x.TiffinAllowanceID);
                    table.ForeignKey(
                        name: "FK_TiffinAllowanceTimes_EmploymentTypes_EmploymentTypeID",
                        column: x => x.EmploymentTypeID,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeID");
                });

            migrationBuilder.CreateTable(
                name: "SalaryGrades",
                columns: table => new
                {
                    SalaryGradeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GradeStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    GradeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryGrades", x => x.SalaryGradeID);
                    table.ForeignKey(
                        name: "FK_SalaryGrades_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineInformations",
                columns: table => new
                {
                    LineID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    UnitID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BuildingID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SectionsID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DivisionID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineInformations", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_LineInformations_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "BuildingID");
                    table.ForeignKey(
                        name: "FK_LineInformations_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_LineInformations_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "DivisionID");
                    table.ForeignKey(
                        name: "FK_LineInformations_Sections_SectionsID",
                        column: x => x.SectionsID,
                        principalTable: "Sections",
                        principalColumn: "SectionsID");
                    table.ForeignKey(
                        name: "FK_LineInformations_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceBonus",
                columns: table => new
                {
                    AttendanceBonusID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BonusAmount = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    BonusCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceBonus", x => x.AttendanceBonusID);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceRecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    OutTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    OTStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    OTEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    TotalRegularHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalOvertimeHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AttendanceConfigurationID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AttendanceStatusID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployeeInformationEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceRecordID);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_AttendanceConfigurations_AttendanceConfigurationID",
                        column: x => x.AttendanceConfigurationID,
                        principalTable: "AttendanceConfigurations",
                        principalColumn: "AttendanceConfigurationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_AttendanceStatuss_AttendanceStatusID",
                        column: x => x.AttendanceStatusID,
                        principalTable: "AttendanceStatuss",
                        principalColumn: "AttendanceStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonusRecords",
                columns: table => new
                {
                    BonusRecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BonusDate = table.Column<DateOnly>(type: "date", nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConveyanceAllowance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OtherAllowance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FestivalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RevenueStampAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPayableAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusRecords", x => x.BonusRecordID);
                });

            migrationBuilder.CreateTable(
                name: "CareerHistories",
                columns: table => new
                {
                    EntryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EntryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerHistories", x => x.EntryNumber);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenInformations",
                columns: table => new
                {
                    ChildID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChildrenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenInformations", x => x.ChildID);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersonInformations",
                columns: table => new
                {
                    ContactID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Relation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersonInformations", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "DateWiseOfficeTimes",
                columns: table => new
                {
                    DateWiseOfficeTimeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShiftStartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShiftEndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConsideredLunchHour = table.Column<TimeOnly>(type: "time", nullable: false),
                    BreakDuration = table.Column<TimeOnly>(type: "time", nullable: false),
                    EmployeeInformationEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWiseOfficeTimes", x => x.DateWiseOfficeTimeID);
                });

            migrationBuilder.CreateTable(
                name: "ShiftEmployees",
                columns: table => new
                {
                    ShiftEmployeeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateWiseOfficeTimeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftEmployees", x => x.ShiftEmployeeID);
                    table.ForeignKey(
                        name: "FK_ShiftEmployees_DateWiseOfficeTimes_DateWiseOfficeTimeID",
                        column: x => x.DateWiseOfficeTimeID,
                        principalTable: "DateWiseOfficeTimes",
                        principalColumn: "DateWiseOfficeTimeID");
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaryActions",
                columns: table => new
                {
                    ActionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryActions", x => x.ActionID);
                });

            migrationBuilder.CreateTable(
                name: "EarlyLeaveInformation",
                columns: table => new
                {
                    EarlyLeaveInformationID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LeaveTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarlyLeaveInformation", x => x.EarlyLeaveInformationID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBenefits",
                columns: table => new
                {
                    BenefitID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BenefitDate = table.Column<DateTime>(type: "date", nullable: true),
                    BenefitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenefitType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BenefitActivationDate = table.Column<DateTime>(type: "date", nullable: true),
                    PreviousNetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewNetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryStepID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    GradeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConveyanceAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryRecordID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CashIncentive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryGradeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBenefits", x => x.BenefitID);
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBenefits_SalaryGrades_SalaryGradeID",
                        column: x => x.SalaryGradeID,
                        principalTable: "SalaryGrades",
                        principalColumn: "SalaryGradeID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeComplaints",
                columns: table => new
                {
                    ComplaintID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplaintType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeComplaints", x => x.ComplaintID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInformations",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsLineSelected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeNameLocal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UnitID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DivisionID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DepartmentID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SectionID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DesignationID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GradeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ShiftEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AttendanceRecordID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsOTAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDentificationMark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PresentAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalIDNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsMobileBanking = table.Column<bool>(type: "bit", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherNameLocal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MotherNameLocal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DistrictOfBirth = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfMarriage = table.Column<DateTime>(type: "date", nullable: true),
                    AppointmentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: true),
                    PostingDate = table.Column<DateTime>(type: "date", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "date", nullable: true),
                    RetirementDate = table.Column<DateTime>(type: "date", nullable: true),
                    ServiceLength = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpouseOccupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SpouseDateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    SpouseBloodGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SalaryRecordID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CurrentSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryAtJoining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryGradeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SalaryStepID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PassportIssueDate = table.Column<DateTime>(type: "date", nullable: true),
                    PassportExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    PassportIssuePlace = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PassportIssueAuthority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseIssueDate = table.Column<DateTime>(type: "date", nullable: true),
                    LicenseExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    LicenseIssuePlace = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseIssueAuthority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MembershipCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Association = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MembershipType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MembershipValIDityDate = table.Column<DateTime>(type: "date", nullable: true),
                    ReferenceName1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceAddress1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReferencePhone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ReferenceOccupation1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenceRelation1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenceName2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceAddress2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReferencePhone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ReferenceOccupation2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenceRelation2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployeePhoto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployeeSignature = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OldEmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousEmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyHoliDay = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformations", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_AttendanceRecords_AttendanceRecordID",
                        column: x => x.AttendanceRecordID,
                        principalTable: "AttendanceRecords",
                        principalColumn: "AttendanceRecordID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Designations_DesignationID",
                        column: x => x.DesignationID,
                        principalTable: "Designations",
                        principalColumn: "DesignationID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "DivisionID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_EmploymentTypes_EmploymentTypeID",
                        column: x => x.EmploymentTypeID,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_LineInformations_LineID",
                        column: x => x.LineID,
                        principalTable: "LineInformations",
                        principalColumn: "LineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_SalaryGrades_SalaryGradeID",
                        column: x => x.SalaryGradeID,
                        principalTable: "SalaryGrades",
                        principalColumn: "SalaryGradeID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionsID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_ShiftEmployees_ShiftEmployeeID",
                        column: x => x.ShiftEmployeeID,
                        principalTable: "ShiftEmployees",
                        principalColumn: "ShiftEmployeeID");
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    SkillID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CertificationDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaxes",
                columns: table => new
                {
                    EmployeeTaxID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryDate = table.Column<DateTime>(type: "date", nullable: false),
                    TaxMonth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MonthlyGross = table.Column<double>(type: "float", nullable: true),
                    CalculatedTax = table.Column<double>(type: "float", nullable: true),
                    ProposedTax = table.Column<double>(type: "float", nullable: true),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaxes", x => x.EmployeeTaxID);
                    table.ForeignKey(
                        name: "FK_EmployeeTaxes_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalBonuses",
                columns: table => new
                {
                    FestivalBonusID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FestivalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PercentageBelowOneYear = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PercentageAfterOneYear = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BonusEligibilityCheck = table.Column<int>(type: "int", nullable: false),
                    FestivalBonusDate = table.Column<DateTime>(type: "date", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "date", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "date", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalBonuses", x => x.FestivalBonusID);
                    table.ForeignKey(
                        name: "FK_FestivalBonuses_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodCharges",
                columns: table => new
                {
                    FoodChargeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChargeDate = table.Column<DateTime>(type: "date", nullable: false),
                    ChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChargeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCharges", x => x.FoodChargeID);
                    table.ForeignKey(
                        name: "FK_FoodCharges_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoliDayBillRates",
                columns: table => new
                {
                    HoliDayBillRateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    SalaryMinimum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryMaximum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoliDayBillRateValue = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoliDayBillRates", x => x.HoliDayBillRateID);
                    table.ForeignKey(
                        name: "FK_HoliDayBillRates_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoliDayEntitledEmployees",
                columns: table => new
                {
                    HoliDayEntitledEmployeeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoliDayEntitledEmployees", x => x.HoliDayEntitledEmployeeID);
                    table.ForeignKey(
                        name: "FK_HoliDayEntitledEmployees_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoliDayInformations",
                columns: table => new
                {
                    HoliDayInformationID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoliDayInformations", x => x.HoliDayInformationID);
                    table.ForeignKey(
                        name: "FK_HoliDayInformations_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLefts",
                columns: table => new
                {
                    JobLeftID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobLeftDate = table.Column<DateTime>(type: "date", nullable: true),
                    JobLeftType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: true),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLefts", x => x.JobLeftID);
                    table.ForeignKey(
                        name: "FK_JobLefts_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LateApprovals",
                columns: table => new
                {
                    LateApprovalID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LateDate = table.Column<DateTime>(type: "date", nullable: false),
                    LateTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LateEntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    LateReason = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LateApprovals", x => x.LateApprovalID);
                    table.ForeignKey(
                        name: "FK_LateApprovals_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApprovals",
                columns: table => new
                {
                    LeaveApprovalID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaveName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LeaveFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaveEnjoyed = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TotalLeave = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LeaveYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ProvidedLeave = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApprovals", x => x.LeaveApprovalID);
                    table.ForeignKey(
                        name: "FK_LeaveApprovals_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "LeaveEncashments",
                columns: table => new
                {
                    LeaveEncashmentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EncashMonth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EncashYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ActualDays = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ComputedDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaveEncashAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    OtherDeductions = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ActualEncashAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ComputedEncashAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastMonthWorkingDays = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveEncashments", x => x.LeaveEncashmentID);
                    table.ForeignKey(
                        name: "FK_LeaveEncashments_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualAttendances",
                columns: table => new
                {
                    ManualAttendanceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    AttendanceTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OutTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAttendances", x => x.ManualAttendanceID);
                    table.ForeignKey(
                        name: "FK_ManualAttendances_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaternityConfigurations",
                columns: table => new
                {
                    MaternityConfigurationID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsEligible = table.Column<bool>(type: "bit", nullable: false),
                    LastWithdrawalDate = table.Column<DateTime>(type: "date", nullable: true),
                    InstallmentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NextWithdrawableTime = table.Column<int>(type: "int", nullable: true),
                    CurrentWithdrawalDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaternityConfigurations", x => x.MaternityConfigurationID);
                    table.ForeignKey(
                        name: "FK_MaternityConfigurations_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomineeInformations",
                columns: table => new
                {
                    NomineeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomineeInformations", x => x.NomineeID);
                    table.ForeignKey(
                        name: "FK_NomineeInformations_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "OverTimes",
                columns: table => new
                {
                    EmployeeOverTimeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OTDate = table.Column<DateTime>(type: "date", nullable: false),
                    OTHours = table.Column<float>(type: "real", nullable: true),
                    OTStartTime = table.Column<DateTime>(type: "date", nullable: true),
                    OTEndTime = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimes", x => x.EmployeeOverTimeID);
                    table.ForeignKey(
                        name: "FK_OverTimes_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProximityRecords",
                columns: table => new
                {
                    ProximityRecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProximityID = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<TimeOnly>(type: "time", nullable: false),
                    RecordTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    InTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    OutTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    AttendanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProximityRecords", x => x.ProximityRecordID);
                    table.ForeignKey(
                        name: "FK_ProximityRecords_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDeductions",
                columns: table => new
                {
                    SalaryDeductionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDeductions", x => x.SalaryDeductionID);
                    table.ForeignKey(
                        name: "FK_SalaryDeductions_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryEntrys",
                columns: table => new
                {
                    SalaryEntryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "date", nullable: false),
                    SalaryHeadName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryEntrys", x => x.SalaryEntryID);
                    table.ForeignKey(
                        name: "FK_SalaryEntrys_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryRecords",
                columns: table => new
                {
                    SalaryRecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    SalaryEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: false),
                    MonthDays = table.Column<int>(type: "int", nullable: false),
                    PunchDays = table.Column<int>(type: "int", nullable: false),
                    TotalHoliDay = table.Column<int>(type: "int", nullable: false),
                    TotalLeave = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: false),
                    Absenteeism = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualGross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MobileAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ByBankAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ByCashAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPayable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConveyanceAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttendanceBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryAdvance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiffinAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Arrear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoliDayBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NightBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryID = table.Column<int>(type: "int", nullable: false),
                    LunchBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MobileBanking = table.Column<bool>(type: "bit", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SectionID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmploymentTypeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SalaryGradeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CompanyID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DepartmentID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DesignationID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GradeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmployeeInformationEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryRecords", x => x.SalaryRecordID);
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Designations_DesignationID",
                        column: x => x.DesignationID,
                        principalTable: "Designations",
                        principalColumn: "DesignationID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_EmployeeInformations_EmployeeInformationEmployeeID",
                        column: x => x.EmployeeInformationEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_EmploymentTypes_EmploymentTypeID",
                        column: x => x.EmploymentTypeID,
                        principalTable: "EmploymentTypes",
                        principalColumn: "EmploymentTypeID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_SalaryGrades_SalaryGradeID",
                        column: x => x.SalaryGradeID,
                        principalTable: "SalaryGrades",
                        principalColumn: "SalaryGradeID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionsID");
                    table.ForeignKey(
                        name: "FK_SalaryRecords_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID");
                });

            migrationBuilder.CreateTable(
                name: "ShiftTimes",
                columns: table => new
                {
                    ShiftID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShiftName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShiftStart = table.Column<DateTime>(type: "date", nullable: false),
                    ShiftEnd = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ConsideredLunchHour = table.Column<int>(type: "int", nullable: true),
                    BreakDuration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTimes", x => x.ShiftID);
                    table.ForeignKey(
                        name: "FK_ShiftTimes_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "SpecialEmployees",
                columns: table => new
                {
                    SpecialEmployeeID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    AttendanceType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialEmployees", x => x.SpecialEmployeeID);
                    table.ForeignKey(
                        name: "FK_SpecialEmployees_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "SpouseInformations",
                columns: table => new
                {
                    SpouseID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpouseInformations", x => x.SpouseID);
                    table.ForeignKey(
                        name: "FK_SpouseInformations_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Suspends",
                columns: table => new
                {
                    SuspendID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuspendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Release = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspends", x => x.SuspendID);
                    table.ForeignKey(
                        name: "FK_Suspends_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "TaxAmounts",
                columns: table => new
                {
                    TaxAmountID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    TaxAmountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAmounts", x => x.TaxAmountID);
                    table.ForeignKey(
                        name: "FK_TaxAmounts_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "TaxExempteds",
                columns: table => new
                {
                    TaxExemptedID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Medical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Conveyance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlyExemptedTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlySpecialExemptedTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeInformationsEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxExempteds", x => x.TaxExemptedID);
                    table.ForeignKey(
                        name: "FK_TaxExempteds_EmployeeInformations_EmployeeInformationsEmployeeID",
                        column: x => x.EmployeeInformationsEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "LeaveEncashmentRates",
                columns: table => new
                {
                    LeaveEncashmentRateID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToGrossSalary = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    RateInPercent = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    LeaveEncashmentID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployeeInformationEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveEncashmentRates", x => x.LeaveEncashmentRateID);
                    table.ForeignKey(
                        name: "FK_LeaveEncashmentRates_EmployeeInformations_EmployeeInformationEmployeeID",
                        column: x => x.EmployeeInformationEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_LeaveEncashmentRates_LeaveEncashments_LeaveEncashmentID",
                        column: x => x.LeaveEncashmentID,
                        principalTable: "LeaveEncashments",
                        principalColumn: "LeaveEncashmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaternityBills",
                columns: table => new
                {
                    MaternityBillID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaternityConfigurationID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CurrentMonth = table.Column<DateTime>(type: "date", nullable: true),
                    FromMonth = table.Column<DateTime>(type: "date", nullable: true),
                    ToMonth = table.Column<DateTime>(type: "date", nullable: true),
                    NumberOfMonths = table.Column<int>(type: "int", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    WorkingDays = table.Column<int>(type: "int", nullable: true),
                    ActualCurrentSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EarnedLeaveDays = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    EarnedLeaveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Computed3MonthNetPayable = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    Computed3MonthWorkingDays = table.Column<int>(type: "int", nullable: true),
                    ActualPay = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ComputedPay = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ActualNetPayable = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    ComputedNetPayable = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    LocalAreaClerance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalAreaRemarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaternityBills", x => x.MaternityBillID);
                    table.ForeignKey(
                        name: "FK_MaternityBills_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_MaternityBills_MaternityConfigurations_MaternityConfigurationID",
                        column: x => x.MaternityConfigurationID,
                        principalTable: "MaternityConfigurations",
                        principalColumn: "MaternityConfigurationID");
                });

            migrationBuilder.CreateTable(
                name: "SalaryProcesss",
                columns: table => new
                {
                    ProcessID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthNo = table.Column<int>(type: "int", nullable: false),
                    YearNo = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SalaryEntryID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryProcesss", x => x.ProcessID);
                    table.ForeignKey(
                        name: "FK_SalaryProcesss_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryProcesss_SalaryEntrys_SalaryEntryID",
                        column: x => x.SalaryEntryID,
                        principalTable: "SalaryEntrys",
                        principalColumn: "SalaryEntryID");
                });

            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    TaxRuleID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinSpecialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxSpecialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "date", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxExemptedID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployeeInformationEmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.TaxRuleID);
                    table.ForeignKey(
                        name: "FK_TaxRules_EmployeeInformations_EmployeeInformationEmployeeID",
                        column: x => x.EmployeeInformationEmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_TaxRules_TaxExempteds_TaxExemptedID",
                        column: x => x.TaxExemptedID,
                        principalTable: "TaxExempteds",
                        principalColumn: "TaxExemptedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRecords",
                columns: table => new
                {
                    LeaveRecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaveYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "date", nullable: false),
                    LeaveTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalLeave = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LeaveEnjoyed = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    EntryUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MaternityBillID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRecords", x => x.LeaveRecordID);
                    table.ForeignKey(
                        name: "FK_LeaveRecords_EmployeeInformations_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeeInformations",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRecords_MaternityBills_MaternityBillID",
                        column: x => x.MaternityBillID,
                        principalTable: "MaternityBills",
                        principalColumn: "MaternityBillID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceBonus_EmployeeID",
                table: "AttendanceBonus",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_AttendanceConfigurationID",
                table: "AttendanceRecords",
                column: "AttendanceConfigurationID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_AttendanceStatusID",
                table: "AttendanceRecords",
                column: "AttendanceStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_EmployeeInformationEmployeeID",
                table: "AttendanceRecords",
                column: "EmployeeInformationEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_BonusRecords_EmployeeID",
                table: "BonusRecords",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CompanyID",
                table: "Buildings",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CareerHistories_EmployeeID",
                table: "CareerHistories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenInformations_EmployeeID",
                table: "ChildrenInformations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonInformations_EmployeeID",
                table: "ContactPersonInformations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DateWiseOfficeTimes_EmployeeInformationEmployeeID",
                table: "DateWiseOfficeTimes",
                column: "EmployeeInformationEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyID",
                table: "Departments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryActions_EmployeeID",
                table: "DisciplinaryActions",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EarlyLeaveInformation_EmployeeID",
                table: "EarlyLeaveInformation",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_EmployeeID",
                table: "EmployeeBenefits",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_GradeID",
                table: "EmployeeBenefits",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_SalaryGradeID",
                table: "EmployeeBenefits",
                column: "SalaryGradeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBenefits_SalaryRecordID",
                table: "EmployeeBenefits",
                column: "SalaryRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeComplaints_EmployeeID",
                table: "EmployeeComplaints",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_AttendanceRecordID",
                table: "EmployeeInformations",
                column: "AttendanceRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_CompanyID",
                table: "EmployeeInformations",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_DepartmentID",
                table: "EmployeeInformations",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_DesignationID",
                table: "EmployeeInformations",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_DivisionID",
                table: "EmployeeInformations",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_EmploymentTypeID",
                table: "EmployeeInformations",
                column: "EmploymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_GradeID",
                table: "EmployeeInformations",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_LineID",
                table: "EmployeeInformations",
                column: "LineID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_SalaryGradeID",
                table: "EmployeeInformations",
                column: "SalaryGradeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_SalaryRecordID",
                table: "EmployeeInformations",
                column: "SalaryRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_SectionID",
                table: "EmployeeInformations",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_ShiftEmployeeID",
                table: "EmployeeInformations",
                column: "ShiftEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_UnitID",
                table: "EmployeeInformations",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeID",
                table: "EmployeeSkills",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaxes_EmployeeID",
                table: "EmployeeTaxes",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalBonuses_EmployeeID",
                table: "FestivalBonuses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharges_EmployeeID",
                table: "FoodCharges",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HoliDayBillRates_EmployeeID",
                table: "HoliDayBillRates",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HoliDayEntitledEmployees_EmployeeID",
                table: "HoliDayEntitledEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HoliDayInformations_EmployeeID",
                table: "HoliDayInformations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_JobLefts_EmployeeID",
                table: "JobLefts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LateApprovals_EmployeeID",
                table: "LateApprovals",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_EmployeeInformationsEmployeeID",
                table: "LeaveApprovals",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveEncashmentRates_EmployeeInformationEmployeeID",
                table: "LeaveEncashmentRates",
                column: "EmployeeInformationEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveEncashmentRates_LeaveEncashmentID",
                table: "LeaveEncashmentRates",
                column: "LeaveEncashmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveEncashments_EmployeeID",
                table: "LeaveEncashments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRecords_EmployeeID",
                table: "LeaveRecords",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRecords_MaternityBillID",
                table: "LeaveRecords",
                column: "MaternityBillID");

            migrationBuilder.CreateIndex(
                name: "IX_LineInformations_BuildingID",
                table: "LineInformations",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_LineInformations_CompanyID",
                table: "LineInformations",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_LineInformations_DivisionID",
                table: "LineInformations",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_LineInformations_SectionsID",
                table: "LineInformations",
                column: "SectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_LineInformations_UnitID",
                table: "LineInformations",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttendances_EmployeeID",
                table: "ManualAttendances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_MaternityBills_EmployeeID",
                table: "MaternityBills",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_MaternityBills_MaternityConfigurationID",
                table: "MaternityBills",
                column: "MaternityConfigurationID");

            migrationBuilder.CreateIndex(
                name: "IX_MaternityConfigurations_EmployeeID",
                table: "MaternityConfigurations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_NightAllowances_EmploymentTypeID",
                table: "NightAllowances",
                column: "EmploymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NightAllowanceTimes_EmploymentTypeID",
                table: "NightAllowanceTimes",
                column: "EmploymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NomineeInformations_EmployeeInformationsEmployeeID",
                table: "NomineeInformations",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimes_EmployeeID",
                table: "OverTimes",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProximityRecords_EmployeeID",
                table: "ProximityRecords",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDeductions_EmployeeID",
                table: "SalaryDeductions",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryEntrys_EmployeeID",
                table: "SalaryEntrys",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryGrades_GradeID",
                table: "SalaryGrades",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProcesss_EmployeeID",
                table: "SalaryProcesss",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProcesss_SalaryEntryID",
                table: "SalaryProcesss",
                column: "SalaryEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_CompanyID",
                table: "SalaryRecords",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_DepartmentID",
                table: "SalaryRecords",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_DesignationID",
                table: "SalaryRecords",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_EmployeeInformationEmployeeID",
                table: "SalaryRecords",
                column: "EmployeeInformationEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_EmploymentTypeID",
                table: "SalaryRecords",
                column: "EmploymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_GradeID",
                table: "SalaryRecords",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_SalaryGradeID",
                table: "SalaryRecords",
                column: "SalaryGradeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_SectionID",
                table: "SalaryRecords",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryRecords_UnitID",
                table: "SalaryRecords",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CompanyID",
                table: "Sections",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftEmployees_DateWiseOfficeTimeID",
                table: "ShiftEmployees",
                column: "DateWiseOfficeTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTimes_EmployeeID",
                table: "ShiftTimes",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialEmployees_EmployeeInformationsEmployeeID",
                table: "SpecialEmployees",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SpouseInformations_EmployeeInformationsEmployeeID",
                table: "SpouseInformations",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Suspends_EmployeeInformationsEmployeeID",
                table: "Suspends",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxAmounts_EmployeeInformationsEmployeeID",
                table: "TaxAmounts",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxExempteds_EmployeeInformationsEmployeeID",
                table: "TaxExempteds",
                column: "EmployeeInformationsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRules_EmployeeInformationEmployeeID",
                table: "TaxRules",
                column: "EmployeeInformationEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRules_TaxExemptedID",
                table: "TaxRules",
                column: "TaxExemptedID");

            migrationBuilder.CreateIndex(
                name: "IX_TiffinAllowanceRates_DesignationID",
                table: "TiffinAllowanceRates",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_TiffinAllowanceTimes_EmploymentTypeID",
                table: "TiffinAllowanceTimes",
                column: "EmploymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CompanyID",
                table: "Units",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceBonus_EmployeeInformations_EmployeeID",
                table: "AttendanceBonus",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_EmployeeInformations_EmployeeInformationEmployeeID",
                table: "AttendanceRecords",
                column: "EmployeeInformationEmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusRecords_EmployeeInformations_EmployeeID",
                table: "BonusRecords",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CareerHistories_EmployeeInformations_EmployeeID",
                table: "CareerHistories",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenInformations_EmployeeInformations_EmployeeID",
                table: "ChildrenInformations",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersonInformations_EmployeeInformations_EmployeeID",
                table: "ContactPersonInformations",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateWiseOfficeTimes_EmployeeInformations_EmployeeInformationEmployeeID",
                table: "DateWiseOfficeTimes",
                column: "EmployeeInformationEmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryActions_EmployeeInformations_EmployeeID",
                table: "DisciplinaryActions",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EarlyLeaveInformation_EmployeeInformations_EmployeeID",
                table: "EarlyLeaveInformation",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBenefits_EmployeeInformations_EmployeeID",
                table: "EmployeeBenefits",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBenefits_SalaryRecords_SalaryRecordID",
                table: "EmployeeBenefits",
                column: "SalaryRecordID",
                principalTable: "SalaryRecords",
                principalColumn: "SalaryRecordID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeComplaints_EmployeeInformations_EmployeeID",
                table: "EmployeeComplaints",
                column: "EmployeeID",
                principalTable: "EmployeeInformations",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformations_SalaryRecords_SalaryRecordID",
                table: "EmployeeInformations",
                column: "SalaryRecordID",
                principalTable: "SalaryRecords",
                principalColumn: "SalaryRecordID");



            /////////////////Rezaul StoreProc/////////////////
           


            //migrationBuilder.Sql(@"
            //    CREATE PROCEDURE InsertDepartment
            //        @DepartmentID NVARCHAR(50),
            //        @DepartmentName NVARCHAR(50),
            //        @DepartmentShortName NVARCHAR(50),
            //        @DepartmentNameLocal NVARCHAR(50),
            //        @CompanyID NVARCHAR(50)
            //    AS
            //    BEGIN
            //        SET NOCOUNT ON;

            //        IF NOT EXISTS (SELECT 1 FROM Companies WHERE CompanyID = @CompanyID)
            //        BEGIN
            //            RAISERROR('Invalid CompanyID: Company does not exist.', 16, 1);
            //            RETURN;
            //        END

            //        INSERT INTO Departments(
            //            DepartmentID,
            //            DepartmentName,
            //            DepartmentShortName,
            //            DepartmentNameLocal,
            //            CompanyID
            //        )
            //        VALUES (
            //            @DepartmentID,
            //            @DepartmentName,
            //            @DepartmentShortName,
            //            @DepartmentNameLocal,
            //            @CompanyID
            //        );
            //    END;"
            //);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_EmployeeInformations_EmployeeInformationEmployeeID",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_DateWiseOfficeTimes_EmployeeInformations_EmployeeInformationEmployeeID",
                table: "DateWiseOfficeTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryRecords_EmployeeInformations_EmployeeInformationEmployeeID",
                table: "SalaryRecords");

            migrationBuilder.DropTable(
                name: "AttendanceBonus");

            migrationBuilder.DropTable(
                name: "BonusRecords");

            migrationBuilder.DropTable(
                name: "CareerHistories");

            migrationBuilder.DropTable(
                name: "ChildrenInformations");

            migrationBuilder.DropTable(
                name: "ContactPersonInformations");

            migrationBuilder.DropTable(
                name: "DisciplinaryActions");

            migrationBuilder.DropTable(
                name: "EarlyLeaveInformation");

            migrationBuilder.DropTable(
                name: "EmployeeBenefits");

            migrationBuilder.DropTable(
                name: "EmployeeComplaints");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeTaxes");

            migrationBuilder.DropTable(
                name: "FestivalBonuses");

            migrationBuilder.DropTable(
                name: "FoodCharges");

            migrationBuilder.DropTable(
                name: "HoliDayBillRates");

            migrationBuilder.DropTable(
                name: "HoliDayEntitledEmployees");

            migrationBuilder.DropTable(
                name: "HoliDayInformations");

            migrationBuilder.DropTable(
                name: "JobLefts");

            migrationBuilder.DropTable(
                name: "LateApprovals");

            migrationBuilder.DropTable(
                name: "LeaveApprovals");

            migrationBuilder.DropTable(
                name: "LeaveEncashmentRates");

            migrationBuilder.DropTable(
                name: "LeaveRecords");

            migrationBuilder.DropTable(
                name: "LogFiles");

            migrationBuilder.DropTable(
                name: "ManualAttendances");

            migrationBuilder.DropTable(
                name: "NightAllowances");

            migrationBuilder.DropTable(
                name: "NightAllowanceTimes");

            migrationBuilder.DropTable(
                name: "NomineeInformations");

            migrationBuilder.DropTable(
                name: "OverTimes");

            migrationBuilder.DropTable(
                name: "ProximityRecords");

            migrationBuilder.DropTable(
                name: "SalaryDeductions");

            migrationBuilder.DropTable(
                name: "SalaryProcesss");

            migrationBuilder.DropTable(
                name: "ShiftTimes");

            migrationBuilder.DropTable(
                name: "SpecialEmployees");

            migrationBuilder.DropTable(
                name: "SpouseInformations");

            migrationBuilder.DropTable(
                name: "Suspends");

            migrationBuilder.DropTable(
                name: "TaxAmounts");

            migrationBuilder.DropTable(
                name: "TaxRules");

            migrationBuilder.DropTable(
                name: "TiffinAllowanceRates");

            migrationBuilder.DropTable(
                name: "TiffinAllowanceTimes");

            migrationBuilder.DropTable(
                name: "LeaveEncashments");

            migrationBuilder.DropTable(
                name: "MaternityBills");

            migrationBuilder.DropTable(
                name: "SalaryEntrys");

            migrationBuilder.DropTable(
                name: "TaxExempteds");

            migrationBuilder.DropTable(
                name: "MaternityConfigurations");

            migrationBuilder.DropTable(
                name: "EmployeeInformations");

            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "LineInformations");

            migrationBuilder.DropTable(
                name: "SalaryRecords");

            migrationBuilder.DropTable(
                name: "ShiftEmployees");

            migrationBuilder.DropTable(
                name: "AttendanceConfigurations");

            migrationBuilder.DropTable(
                name: "AttendanceStatuss");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropTable(
                name: "SalaryGrades");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "DateWiseOfficeTimes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
