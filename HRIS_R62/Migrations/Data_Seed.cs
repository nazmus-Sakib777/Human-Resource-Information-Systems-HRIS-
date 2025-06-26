using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class DatainsertedtoGradeandSalaryGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AttendanceStatuss",
                columns: new[] { "AttendanceStatusID", "StatusName", "StatusShortName" },
                values: new object[,]
                {
                    { "P", "Present", "P" },
                    { "A", "Absent", "A" },
                    { "OL", "On Leave", "On L" },
                    { "WFH", "Work From Home", "WFH" },
                    { "L", "Late", "L" }
                });

            migrationBuilder.InsertData(
                table: "AttendanceConfigurations",
                columns: new[] { "AttendanceConfigurationID", "GraceTime", "LunchBreakStartTime", "LunchBreakEndTime", "EveningSnacksBreakStartTime", "EveningSnacksBreakEndTime" },
                values: new object[,]
               {
                { "Config1", "15 min", TimeOnly.Parse("12:30:00"), TimeOnly.Parse("13:30:00"), TimeOnly.Parse("16:00:00"), TimeOnly.Parse("16:15:00") },
                { "Config2", "30 min", TimeOnly.Parse("13:00:00"), TimeOnly.Parse("14:00:00"), TimeOnly.Parse("15:30:00"), TimeOnly.Parse("15:45:00") },
                { "Config3", "10 min", TimeOnly.Parse("12:45:00"), TimeOnly.Parse("13:15:00"), TimeOnly.Parse("16:15:00"), TimeOnly.Parse("16:30:00") },
                { "Config4", "20 min", TimeOnly.Parse("12:00:00"), TimeOnly.Parse("13:00:00"), TimeOnly.Parse("15:45:00"), TimeOnly.Parse("16:00:00") },
                { "Config5", "25 min", TimeOnly.Parse("13:15:00"), TimeOnly.Parse("14:15:00"), TimeOnly.Parse("16:30:00"), TimeOnly.Parse("16:45:00") }
               });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "CompanyName", "CompanyShortName", "CompanyNameLocal", "CompanyAddress", "PhoneNumber", "FaxNumber", "Email" },
                values: new object[,]
               {
                { "C001", "Tech Solutions Ltd.", "TSL", "Tech", "12 Gulshan Avenue, Dhaka", "01711112222", "880-2-8822333", "info@techsl.com" },
                { "C002", "Delta Garments", "DG", "Delta", "House 45, Uttara, Dhaka", "01822223333", "880-2-8822444", "contact@deltagarm.com" },
                { "C003", "Green Life Pharma", "GLP", "Green", "45 Green Road, Dhaka", "01933334444", "880-2-8822555", "support@glpharma.com" },
                { "C004", "Blue Ocean Textiles", "BOT", "Blue", "Plot 22, CEPZ, Chittagong", "01755556666", "880-31-772200", "hr@blueoceantx.com" },
                { "C005", "Star Logistics", "SL", "Star", "Airport Road, Dhaka", "01677778888", "880-2-8822666", "logistics@starltd.com" }
               });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingID", "Floor", "RoomNumber", "Name", "CompanyID" },
                values: new object[,]
            {
                { "B001", "1st Floor", "101", "Main Office", "C001" },
                { "B002", "2nd Floor", "201", "HR Department", "C001" },
                { "B003", "3rd Floor", "301", "IT Department", "C001" },
                { "B004", "Ground Floor", "G01", "Reception", "C001" },
                { "B005", "1st Floor", "102", "Conference Room", "C001" }
            });

            migrationBuilder.InsertData(
            table: "Units",
            columns: new[] { "UnitID", "UnitName", "CompanyID" },
            values: new object[,]
            {
                { "U001", "Unit A", "C001" },
                { "U002", "Unit B", "C001" },
                { "U003", "Unit C", "C001" },
                { "U004", "Unit D", "C001" },
                { "U005", "Unit E", "C001" }
            });


            migrationBuilder.InsertData(
            table: "Sections",
            columns: new[] { "SectionsID", "SectionName", "SectionShortName", "SectionNameNative", "CompanyID" },
            values: new object[,]
            {
                { "S001", "Production", "PRD", "Production", "C001" },
                { "S002", "Quality", "QTY", "Quality", "C001" },
                { "S003", "Maintenance", "MNT", "Maintenance", "C001" },
                { "S004", "HR", "HR", "HR", "C001" },
                { "S005", "Logistics", "LOG", "Logistics", "C001" }
            });

            migrationBuilder.InsertData(
            table: "Divisions",
            columns: new[] { "DivisionID", "DivisionName", "DivisionShortName", "DivisionNameLocal" },
            values: new object[,]
            {
                { "D001", "Manufacturing", "MFG", "Manufacturing" },
                { "D002", "Sales", "SLS", "Sales" },
                { "D003", "Finance", "FIN", "Finance" },
                { "D004", "Research", "R&D", "Research" },
                { "D005", "Customer Service", "CS", "Customer" }
            });

            migrationBuilder.InsertData(
            table: "LineInformations",
            columns: new[] { "LineID", "LineName", "EntryDate", "UnitID", "BuildingID", "SectionsID", "CompanyID", "DivisionID" },
            values: new object[,]
            {
                { "L001", "Line A", DateTime.Parse("2025-05-27"), "U001", "B001", "S001", "C001", "D001" },
                { "L002", "Line B", DateTime.Parse("2025-05-27"), "U002", "B002", "S002", "C001", "D002" },
                { "L003", "Line C", DateTime.Parse("2025-05-27"), "U001", "B003", "S001", "C002", "D001" },
                { "L004", "Line D", DateTime.Parse("2025-05-27"), "U003", "B001", "S003", "C002", "D003" },
                { "L005", "Line E", DateTime.Parse("2025-05-27"), null, "B002", "S002", "C001", "D002" }
            });

            migrationBuilder.InsertData(
            table: "Departments",
            columns: new[] { "DepartmentID", "DepartmentName", "DepartmentShortName", "DepartmentNameLocal", "CompanyID" },
            values: new object[,]
            {
                { "D001", "Human Resources", "HR", "Human", "C001" },
                { "D002", "Finance", "FIN", "Finance", "C001" },
                { "D003", "Production", "PROD", "Production", "C002" },
                { "D004", "IT Department", "IT", "IT", "C003" },
                { "D005", "Sales & Marketing", "S&M", "Sales", "C002" }
            });

            migrationBuilder.InsertData(
            table: "Designations",
            columns: new[] { "DesignationID", "DesignationName", "DesignationNameLocal" },
            values: new object[,]
            {
                { "DSG001", "Manager", "Manager" },
                { "DSG002", "Assistant Manager", "Assistant" },
                { "DSG003", "Executive", "Executive" },
                { "DSG004", "Technician", "Technician" },
                { "DSG005", "Operator", "Operator" }
            });

            migrationBuilder.InsertData(
            table: "Grades",
            columns: new[]
            {
                "GradeID", "GradeShortID", "GradeName", "FromGrossSalary", "ToGrossSalary",
                "Gross", "Basic", "HouseRent", "Medical", "ConveyanceAllowance", "LunchAllowance"
            },
            values: new object[,]
            {
                { "GRD001", "G1", "Grade A", 30000m, 39999m, 35000m, 17500m, 10500m, 1500m, 2000m, 1500m },
                { "GRD002", "G2", "Grade B", 20000m, 29999m, 25000m, 12500m, 7500m, 1200m, 1800m, 1000m },
                { "GRD003", "G3", "Grade C", 15000m, 19999m, 17000m, 8500m, 5100m, 1000m, 1600m, 800m },
                { "GRD004", "G4", "Grade D", 10000m, 14999m, 12000m, 6000m, 3600m, 800m, 1400m, 700m },
                { "GRD005", "G5", "Grade E", 5000m, 9999m, 8000m, 4000m, 2400m, 500m, 1200m, 600m }
            });

            migrationBuilder.InsertData(
            table: "DateWiseOfficeTimes",
            columns: new[] { "DateWiseOfficeTimeID", "ShiftStartDateTime", "ShiftEndDateTime", "ConsideredLunchHour", "BreakDuration" },
            values: new object[,]
            {
                { "DOT001", DateTime.Parse("2025-05-01 08:00:00"), DateTime.Parse("2025-05-01 17:00:00"), TimeOnly.Parse("01:00:00"), TimeOnly.Parse("00:30:00") },
                { "DOT002", DateTime.Parse("2025-05-01 09:00:00"), DateTime.Parse("2025-05-01 18:00:00"), TimeOnly.Parse("01:00:00"), TimeOnly.Parse("00:45:00") },
                { "DOT003", DateTime.Parse("2025-05-02 07:30:00"), DateTime.Parse("2025-05-02 16:30:00"), TimeOnly.Parse("00:45:00"), TimeOnly.Parse("00:30:00") },
                { "DOT004", DateTime.Parse("2025-05-03 08:30:00"), DateTime.Parse("2025-05-03 17:30:00"), TimeOnly.Parse("01:00:00"), TimeOnly.Parse("00:15:00") },
                { "DOT005", DateTime.Parse("2025-05-04 09:00:00"), DateTime.Parse("2025-05-04 18:00:00"), TimeOnly.Parse("01:00:00"), TimeOnly.Parse("00:30:00") }
            });

            migrationBuilder.InsertData(
            table: "ShiftEmployees",
            columns: new[] { "ShiftEmployeeID", "FromDate", "ToDate", "DateWiseOfficeTimeID" },
            values: new object[,]
            {
                { "SE001", DateTime.Parse("2025-01-01"), DateTime.Parse("2025-06-30"), "DOT001" },
                { "SE002", DateTime.Parse("2025-02-01"), null, "DOT002" },
                { "SE003", DateTime.Parse("2025-03-01"), DateTime.Parse("2025-09-30"), "DOT003" },
                { "SE004", DateTime.Parse("2025-04-01"), null, "DOT004" },
                { "SE005", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-12-31"), "DOT005" }
            });

            migrationBuilder.InsertData(
            table: "EmploymentTypes",
            columns: new[] { "EmploymentTypeID", "EmploymentTypeName" },
            values: new object[,]
            {
                { "EMP_TYPE_001", "Permanent" },
                { "EMP_TYPE_002", "Contractual" },
                { "EMP_TYPE_003", "Temporary" },
                { "EMP_TYPE_004", "Part-Time" },
                { "EMP_TYPE_005", "Intern" }
            });

            migrationBuilder.InsertData(
            table: "SalaryGrades",
            columns: new[] { "SalaryGradeID", "GradeName", "GradeStatus", "RuleName", "EffectiveDate", "GradeID" },
            values: new object[,]
            {
                { "SG001", "Junior Officer Grade", "Active", "Rule2020", DateTime.Parse("2023-01-01"), "GRD001" },
                { "SG002", "Officer Grade", "Active", "Rule2021", DateTime.Parse("2023-06-01"), "GRD002" },
                { "SG003", "Senior Officer Grade", "Active", "Rule2022", DateTime.Parse("2023-11-15"), "GRD003" },
                { "SG004", "Assistant Manager Grade", "Active", "Rule2023", DateTime.Parse("2024-02-10"), "GRD004" },
                { "SG005", "Manager Grade", "Active", "Rule2024", DateTime.Parse("2024-05-25"), "GRD005" }
            });

            migrationBuilder.InsertData(
            table: "SalaryRecords",
            columns: new[]
            {
                "SalaryRecordID", "SalaryStartDate", "SalaryEndDate", "JoiningDate", "MonthDays", "PunchDays",
                "TotalHoliDay", "TotalLeave", "WorkingDays", "Absenteeism", "Gross", "ActualGross", "Basic",
                "HouseRent", "MedicalAllowance", "MobileAllowance", "OtherAllowances", "LunchAllowance",
                "Tax", "OtherDeduction", "OTHours", "OTAmount", "ByBankAmount", "ByCashAmount", "NetPayable",
                "ConveyanceAllowance", "AttendanceBonus", "SpecialAllowance", "SalaryAdvance", "FoodCharge",
                "OTRate", "TiffinAllowance", "Arrear", "SpecialBonus", "LeaveStatus", "HoliDayBillAmount",
                "NightBillAmount", "SalaryID", "LunchBillAmount", "MobileBanking", "AccountNumber", "BankName",
                "ProcessDate", "UnitID", "SectionID", "EmploymentTypeID", "SalaryGradeID", "CompanyID", "DepartmentID",
                "DesignationID", "GradeID"
            },
            values: new object[,]
            {
                {
                    "SR001", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-05-31"), DateTime.Parse("2025-01-10"), 31, 30,
                    2, 1, 28, 0.0, 50000.00, 50000.00, 20000.00, 10000.00, 5000.00, 1000.00, 2000.00, 1500.00,
                    5000.00, 500.00, 10.0, 1000.00, 25000.00, 25000.00, 45000.00, 2000.00, 1000.00, 1500.00,
                    2000.00, 500.00, 50.00, 100.00, 200.00, 300.00, "Active", 1000.00, 2000.00, 1, 500.00, true,
                    "ACC123456", "Bank ABC", DateTime.Parse("2025-05-27"), "U001", "S001", "EMP_TYPE_001", "SG001", "C001", "D001", "DSG001", "GRD001"
                },
                {
                    "SR002", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-05-31"), DateTime.Parse("2024-11-15"), 31, 29,
                    2, 2, 27, 1.0, 48000.00, 47000.00, 19000.00, 9500.00, 4800.00, 800.00, 1000.00, 1200.00,
                    4500.00, 300.00, 15.0, 1500.00, 23500.00, 23000.00, 44000.00, 1800.00, 900.00, 1200.00,
                    1800.00, 400.00, 60.00, 90.00, 150.00, 250.00, "Active", 900.00, 1500.00, 2, 400.00, false,
                    "ACC654321", "Bank XYZ", DateTime.Parse("2025-05-27"), "U002", "S002", "EMP_TYPE_002", "SG002", "C002", "D002", "DSG002", "GRD002"
                },
                {
                    "SR003", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-05-31"), DateTime.Parse("2023-03-01"), 31, 31,
                    0, 0, 31, 0.0, 60000.00, 60000.00, 25000.00, 12000.00, 6000.00, 1100.00, 1300.00, 1700.00,
                    6000.00, 400.00, 12.0, 1200.00, 28000.00, 28000.00, 51000.00, 2200.00, 1100.00, 1600.00,
                    2300.00, 600.00, 55.00, 110.00, 220.00, 330.00, "Active", 1100.00, 2000.00, 3, 600.00, true,
                    "ACC999999", "Bank DEF", DateTime.Parse("2025-05-27"), "U003", "S003", "EMP_TYPE_003", "SG003", "C003", "D003", "DSG003", "GRD003"
                },
                {
                    "SR004", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-05-31"), DateTime.Parse("2022-06-05"), 31, 28,
                    3, 1, 27, 0.0, 40000.00, 39500.00, 16000.00, 8000.00, 4000.00, 900.00, 1000.00, 1300.00,
                    4000.00, 350.00, 8.0, 800.00, 20000.00, 19000.00, 39000.00, 1700.00, 850.00, 1400.00,
                    1800.00, 450.00, 45.00, 80.00, 190.00, 260.00, "Active", 950.00, 1700.00, 4, 450.00, false,
                    "ACC121212", "Bank GHI", DateTime.Parse("2025-05-27"), "U004", "S004", "EMP_TYPE_004", "SG004", "C004", "D004", "DSG004", "GRD004"
                },
                {
                    "SR005", DateTime.Parse("2025-05-01"), DateTime.Parse("2025-05-31"), DateTime.Parse("2021-08-20"), 31, 27,
                    4, 1, 26, 1.5, 52000.00, 51000.00, 21000.00, 10500.00, 5200.00, 1000.00, 2200.00, 1600.00,
                    5200.00, 450.00, 11.0, 1100.00, 25500.00, 25500.00, 46500.00, 1900.00, 950.00, 1550.00,
                    2100.00, 550.00, 52.00, 95.00, 210.00, 310.00, "Active", 1050.00, 1900.00, 5, 550.00, true,
                    "ACC333333", "Bank JKL", DateTime.Parse("2025-05-27"), "U005", "S005", "EMP_TYPE_005", "SG005", "C005", "D005", "DSG005", "GRD005"
                }
            });

            migrationBuilder.InsertData(
            table: "AttendanceRecords",
            columns: new[]
            {
                    "AttendanceRecordID", "AttendanceDate", "InTime", "OutTime", "OTStart", "OTEnd",
                    "TotalRegularHours", "TotalOvertimeHours", "DayType", "AttendanceConfigurationID", "AttendanceStatusID"
            },
            values: new object[,]
            {
                    { "AR001", new DateTime(2025, 5, 27), TimeOnly.Parse("08:00:00"), TimeOnly.Parse("17:00:00"), TimeOnly.Parse("17:30:00"), TimeOnly.Parse("19:00:00"), TimeOnly.Parse("09:00:00"), TimeOnly.Parse("01:30:00"), "Weekday", "Config1", "P" },
                    { "AR002", new DateTime(2025, 5, 26), TimeOnly.Parse("08:15:00"), TimeOnly.Parse("17:05:00"), TimeOnly.Parse("17:30:00"), TimeOnly.Parse("18:30:00"), TimeOnly.Parse("08:50:00"), TimeOnly.Parse("01:00:00"), "Weekday", "Config2", "A" },
                    { "AR003", new DateTime(2025, 5, 25), TimeOnly.Parse("08:00:00"), TimeOnly.Parse("17:00:00"), TimeOnly.Parse("00:00:00"), TimeOnly.Parse("00:00:00"), TimeOnly.Parse("09:00:00"), TimeOnly.Parse("00:00:00"), "Weekend", "Config3", "OL" },
                    { "AR004", new DateTime(2025, 5, 24), TimeOnly.Parse("08:45:00"), TimeOnly.Parse("17:00:00"), TimeOnly.Parse("17:10:00"), TimeOnly.Parse("18:00:00"), TimeOnly.Parse("08:15:00"), TimeOnly.Parse("00:50:00"), "Weekday", "Config4", "WFH" },
                    { "AR005", new DateTime(2025, 5, 23), TimeOnly.Parse("08:00:00"), TimeOnly.Parse("16:00:00"), TimeOnly.Parse("00:00:00"), TimeOnly.Parse("00:00:00"), TimeOnly.Parse("08:00:00"), TimeOnly.Parse("00:00:00"), "Weekday", "Config5", "L" }
            });
            migrationBuilder.InsertData(
                table: "EmployeeInformations",
                columns: new[]
                {
                "EmployeeID", "IsLineSelected", "LineID", "EmployeeName", "EmployeeNameLocal", "CompanyID", "UnitID", "DivisionID",
                "DepartmentID", "SectionID", "DesignationID", "GradeID", "ShiftEmployeeID", "IsOTAllowed", "Gender",
                "IDentificationMark", "EmploymentTypeID", "PresentAddress", "PermanentAddress", "Telephone", "MobileNumber",
                "Email", "NationalIDNumber", "IsMobileBanking", "AccountNumber", "BankName", "FatherName", "FatherNameLocal",
                "FatherOccupation", "MotherName", "MotherNameLocal", "MotherOccupation", "DateOfBirth", "PlaceOfBirth",
                "DistrictOfBirth", "Nationality", "Religion", "BloodGroup", "Age", "MaritalStatus", "DateOfMarriage",
                "AppointmentType", "JoiningDate", "PostingDate", "ConfirmationDate", "RetirementDate", "ServiceLength",
                "SpouseName", "SpouseOccupation", "SpouseDateOfBirth", "SpouseBloodGroup", "SalaryRecordID", "CurrentSalary",
                "SalaryAtJoining", "SalaryGradeID", "SalaryStepID", "PassportNumber", "PassportIssueDate", "PassportExpiryDate",
                "PassportIssuePlace", "PassportIssueAuthority", "LicenseNumber", "LicenseIssueDate", "LicenseExpiryDate",
                "LicenseIssuePlace", "LicenseIssueAuthority", "MembershipCardNumber", "Association", "MembershipType",
                "MembershipValIDityDate", "ReferenceName1", "ReferenceAddress1", "ReferencePhone1", "ReferenceOccupation1",
                "ReferenceRelation1", "ReferenceName2", "ReferenceAddress2", "ReferencePhone2", "ReferenceOccupation2",
                "ReferenceRelation2", "LocalAreaClerance", "LocalAreaRemarks", "EmployeePhoto", "EmployeeSignature",
                "OldEmployeeID", "PreviousEmployeeID", "WeeklyHoliDay", "ApprovedDate", "EmployeeStatus"
                    },
                values: new object[,]
                {
            {
                "E001", "Yes", "L001", "John Doe", "John", "C001", "U001", "D001",
                "D001", "S001", "DSG001", "GRD001", "SE001", true, "Male",
                "Scar on left cheek", "EMP_TYPE_001", "123 Main St", "456 Elm St", "0123456789", "01712345678",
                "john.doe@example.com", "NID123456789", true, "1234567890", "ABC Bank", "Robert Doe", "Robert",
                "Engineer", "Mary Doe", "Mary", "Teacher", new DateTime(1985, 4, 15), "Dhaka", "Dhaka", "Bangladeshi",
                "Islam", "A+", 40, "Married", new DateTime(2010, 6, 10), "Permanent", new DateTime(2010, 6, 1),
                new DateTime(2010, 6, 15), new DateTime(2011, 6, 15), new DateTime(2045, 6, 1), "15 years", "Jane Doe",
                "Housewife", new DateTime(1987, 8, 22), "O+", null, 50000m, 30000m, "SG001", "SS001",
                "P1234567", new DateTime(2015, 1, 1), new DateTime(2025, 1, 1), "Dhaka", "Dhaka Authority",
                "L1234567", new DateTime(2016, 1, 1), new DateTime(2026, 1, 1), "Dhaka", "Dhaka Authority",
                "MC12345", "Association A", "Type A", new DateTime(2025, 12, 31),
                "Ref One", "123 Reference St", "0123456789", "Engineer", "Friend",
                "Ref Two", "456 Reference Ave", "0987654321", "Doctor", "Relative",
                "Clear", "Remarks here", "photo.jpg", "signature.jpg", "OLD001", "PREV001", "Friday", new DateTime(2020, 1, 1), "Active"
            },
            {
                "E002", "No", "L002", "Alice Smith", "Alice", "C002", "U002", "D002", "D002", "S002", "DSG002",
                "GRD002", "SE002", false, "Female", "Mole on neck", "EMP_TYPE_002", "789 Pine St", "321 Oak St", "0987654321",
                "01898765432", "alice.smith@example.com", "NID987654321", false, "0987654321", "XYZ Bank", "Michael Smith", "Michael", "Manager",
                "Sarah Smith", "Sarah", "Nurse", new DateTime(1990, 7, 20), "Chittagong", "Chittagong", "Bangladeshi", "Hindu", "B+", 35,
                "Single", null, "Contractual", new DateTime(2015, 9, 15), new DateTime(2015, 10, 1), new DateTime(2016, 10, 1), null, "5 years", "N/A",
                "N/A", null, null, null, 45000m, 35000m, "SG002", "SS002",
                "P7654321", new DateTime(2016, 3, 1), new DateTime(2026, 3, 1), "Chittagong", "Chittagong Authority", "L7654321", new DateTime(2017, 3, 1),
                new DateTime(2027, 3, 1), "Chittagong", "Chittagong Authority", "MC54321", "Association B", "Type B", new DateTime(2027, 6, 30),
                "Ref A", "789 Reference St", "0234567891", "Teacher", "Colleague", "Ref B", "654 Reference Blvd", "1098765432",
                "Engineer", "Friend", "Clear", "No remarks", "photo2.jpg", "signature2.jpg", "OLD002", "PREV002", "Saturday", new DateTime(2019, 5, 5), "Inactive"
        },
                {
                "E003", "Yes", "L003", "Bob Johnson", "Bob", "C003", "U003", "D003", "D003", "S003", "DSG003",
                "GRD003", "SE003", true, "Male", "Tattoo on arm", "EMP_TYPE_003", "135 Maple St", "246 Birch St", "0112233445",
                "01911223344", "bob.johnson@example.com", "NID112233445", true, "1122334455", "DEF Bank", "William Johnson", "William", "Clerk",
                "Emma Johnson", "Emma", "Artist", new DateTime(1982, 11, 5), "Khulna", "Khulna", "Bangladeshi", "Christian", "AB-", 43,
                "Married", new DateTime(2008, 3, 20), "Permanent", new DateTime(2008, 3, 10), new DateTime(2008, 3, 25), new DateTime(2009, 3, 25), new DateTime(2043, 3, 1), "17 years", "Anna Johnson",
                "Teacher", new DateTime(1985, 9, 15), "B+", null, 55000m, 32000m, "SG003", "SS003",
                "P1122334", new DateTime(2014, 5, 1), new DateTime(2024, 5, 1), "Khulna", "Khulna Authority", "L1122334", new DateTime(2015, 5, 1),
                new DateTime(2025, 5, 1), "Khulna", "Khulna Authority", "MC67890", "Association C", "Type C", new DateTime(2024, 12, 31),
                "Ref X", "135 Reference St", "0147852369", "Driver", "Neighbor", "Ref Y", "246 Reference Ave", "0198745632",
                "Engineer", "Friend", "Clear", "Some remarks", "photo3.jpg", "signature3.jpg", "OLD003", "PREV003", "Sunday", new DateTime(2018, 3, 3), "Active"
    },
                    {
                "E004", "No", "L004", "Carol White", "Carol", "C004", "U004", "D004", "D004", "S004", "DSG004",
                "GRD004", "SE004", false, "Female", "Scar on right hand", "EMP_TYPE_004", "246 Cedar St", "135 Spruce St", "0223344556",
                "01644556677", "carol.white@example.com", "NID223344556", false, "2233445566", "GHI Bank", "David White", "David", "Supervisor",
                "Nancy White", "Nancy", "Doctor", new DateTime(1988, 12, 10), "Rajshahi", "Rajshahi", "Bangladeshi", "Muslim", "O-", 37,
                "Married", new DateTime(2012, 11, 25), "Permanent", new DateTime(2012, 11, 20), new DateTime(2012, 12, 5), new DateTime(2013, 12, 5), new DateTime(2047, 11, 20), "13 years", "Mark White",
                "Engineer", new DateTime(1990, 6, 30), "A+", null, 48000m, 33000m, "SG004", "SS004",
                "P2233445", new DateTime(2017, 2, 1), new DateTime(2027, 2, 1), "Rajshahi", "Rajshahi Authority", "L2233445", new DateTime(2018, 2, 1),
                new DateTime(2028, 2, 1), "Rajshahi", "Rajshahi Authority", "MC98765", "Association D", "Type D", new DateTime(2026, 11, 30),
                "Ref M", "246 Reference Rd", "0176543210", "Engineer", "Friend", "Ref N", "135 Reference Ln", "0198765430",
                "Teacher", "Colleague", "Clear", "No remarks", "photo4.jpg", "signature4.jpg", "OLD004", "PREV004", "Thursday", new DateTime(2021, 6, 1), "Active"
    },    {
                "E005", "Yes", "L005", "David Brown", "David", "C005", "U005", "D005", "D005", "S005", "DSG005",
                "GRD005", "SE005", true, "Male", "Birthmark on neck", "EMP_TYPE_005", "357 Willow St", "468 Aspen St", "0334455667",
                "01555667788", "david.brown@example.com", "NID334455667", true, "3344556677", "JKL Bank", "George Brown", "George", "Technician",
                "Lisa Brown", "Lisa", "Nurse", new DateTime(1992, 5, 17), "Sylhet", "Sylhet", "Bangladeshi", "Buddhist", "B-", 32,
                "Single", null, "Contractual", new DateTime(2018, 7, 10), new DateTime(2018, 7, 25), new DateTime(2019, 7, 25), null, "4 years", "N/A",
                "N/A", null, null, null, 47000m, 31000m, "SG005", "SS005",
                "P3344556", new DateTime(2019, 1, 1), new DateTime(2029, 1, 1), "Sylhet", "Sylhet Authority", "L3344556", new DateTime(2020, 1, 1),
                new DateTime(2030, 1, 1), "Sylhet", "Sylhet Authority", "MC13579", "Association E", "Type E", new DateTime(2029, 12, 31),
                "Ref Z", "357 Reference St", "0151234567", "Accountant", "Colleague", "Ref W", "468 Reference Ave", "0167654321",
                "Engineer", "Friend", "Clear", "Remarks here", "photo5.jpg", "signature5.jpg", "OLD005", "PREV005", "Monday", new DateTime(2022, 8, 15), "Active"
    }
                });










            migrationBuilder.InsertData(
            table: "LeaveApprovals",
            columns: new[] { "LeaveApprovalID", "ApprovedDate", "EmployeeID", "EmployeeInformationsEmployeeID", "EntryUser", "LeaveEnjoyed", "LeaveFromDate", "LeaveName", "LeaveToDate", "LeaveYear", "LocalAreaClerance", "LocalAreaRemarks", "ProvidedLeave", "Remarks", "TotalLeave" },
            values: new object[,]
            {
                     { "LA001", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "E001", null, "admin", "2", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical Leave", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "Yes", "Verified by local supervisor", "10", "Approved due to health issue", "12" },
                     { "LA002", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "E002", null, "manager01", "1", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Casual Leave", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "Yes", "Cleared without issue", "10", "For personal work", "10" },
                     { "LA003", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "E003", null, "hruser", "5", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earned Leave", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "Yes", "Approved by dept head", "12", "Long family vacation", "15" },
                     { "LA004", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "E004", null, "admin", "2", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergency Leave", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "No", "Not required", "8", "Urgent home visit", "8" },
                     { "LA005", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "E005", null, "admin", "7", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paternity Leave", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "Yes", "All docs submitted", "7", "New baby arrival", "7" }
            });

            migrationBuilder.InsertData(
                table: "LeaveEncashments",
                columns: new[] { "LeaveEncashmentID", "ActualDays", "ActualEncashAmount", "ApprovedDate", "BasicSalary", "ComputedDays", "ComputedEncashAmount", "EmployeeID", "EncashMonth", "EncashYear", "LastMonthWorkingDays", "LeaveEncashAmount", "LocalAreaClerance", "LocalAreaRemarks", "OtherDeductions" },
                values: new object[,]
                {
                 { "LE001", "28", 8500m, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000m, "26", 8800m, "E001", "01", "2025", 21, 9000m, "Yes", "Approved", 500m },
                    { "LE002", "30", 9600m, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 48000m, "29", 9900m, "E002", "02", "2025", 20, 10000m, "Yes", "Verified", 400m },
                    { "LE003", "30", 9700m, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 52000m, "28", 10100m, "E003", "03", "2025", 23, 10500m, "Yes", "Clean", 800m },
                    { "LE004", "31", 11000m, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000m, "30", 11500m, "E004", "04", "2025", 24, 12000m, "Yes", "OK", 1000m },
                    { "LE005", "30", 12300m, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000m, "28", 12800m, "E005", "05", "2025", 22, 13000m, "Yes", "Checked", 700m }
                });

            migrationBuilder.InsertData(
                table: "LeaveRecords",
                columns: new[] { "LeaveRecordID", "ApprovedDate", "DeliveryDate", "EmployeeID", "EntryDate", "EntryUser", "LeaveDate", "LeaveEnjoyed", "LeaveTime", "LeaveType", "LeaveYear", "MaternityBillID", "Reason", "TotalLeave" },
                values: new object[,]
                {
                    { "LR001", new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "E001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Full Day", "Sick Leave", "2025", null, "Medical checkup", "12" },
                    { "LR002", new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "E002", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager01", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "Half Day", "Casual Leave", "2025", null, "Personal work", "10" },
                    { "LR003", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "E003", new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "hrteam", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "Full Day", "Emergency Leave", "2025", null, "Family emergency", "8" },
                    { "LR004", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "E004", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", "Full Day", "Earned Leave", "2025", null, "Travel plan", "15" },
                    { "LR005", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "E005", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "4", "Half Day", "Casual Leave", "2025", null, "Function at home", "10" }
                });

            migrationBuilder.InsertData(
                table: "MaternityConfigurations",
                columns: new[] { "MaternityConfigurationID", "CurrentWithdrawalDate", "EmployeeID", "InstallmentType", "IsEligible", "JoiningDate", "LastWithdrawalDate", "NextWithdrawableTime", "Status" },
                values: new object[,]
                {
                    { "MC001", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "E001", "Monthly", true, new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Active" },
                    { "MC002", null, "E002", "One-Time", false, new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Inactive" },
                    { "MC003", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "E003", "Monthly", true, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pending" },
                    { "MC004", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E004", "Quarterly", true, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Active" },
                    { "MC005", null, "E005", "One-Time", false, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Not Eligible" }
                });

            migrationBuilder.InsertData(
                table: "LeaveEncashmentRates",
                columns: new[] { "LeaveEncashmentRateID", "EmployeeInformationEmployeeID", "LeaveEncashmentID", "RateInPercent", "ToGrossSalary" },
                values: new object[,]
                {
                    { "LER001", null, "LE001", 10m, 45000m },
                    { "LER002", null, "LE002", 12m, 48000m },
                    { "LER003", null, "LE003", 11m, 52000m },
                    { "LER004", null, "LE004", 13m, 55000m },
                    { "LER005", null, "LE005", 14m, 60000m }
                });

            migrationBuilder.InsertData(
                table: "MaternityBills",
                columns: new[] { "MaternityBillID", "ActualCurrentSalary", "ActualNetPayable", "ActualPay", "ApprovedDate", "BasicSalary", "Computed3MonthNetPayable", "Computed3MonthWorkingDays", "ComputedNetPayable", "ComputedPay", "CurrentMonth", "EarnedLeaveAmount", "EarnedLeaveDays", "EmployeeID", "EntryDate", "FromMonth", "LocalAreaClerance", "LocalAreaRemarks", "MaternityConfigurationID", "NumberOfMonths", "ToMonth", "WorkingDays" },
                values: new object[,]
                {
                    { "MB001", 10000.00m, 29000.0000m, 27000.0000m, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000.00m, 27000.0000m, 66, 29000.0000m, 27000.0000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.00m, 2m, "E001", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes", "Approved by zone", "MC001", 3, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 66 },
                    { "MB002", 11666.67m, 35000.0000m, 32000.0000m, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 35000.00m, 32000.0000m, 69, 35000.0000m, 32000.0000m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000.00m, 3m, "E002", new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes", "Checked by admin", "MC002", 3, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 69 },
                    { "MB003", 9333.33m, 26000.0000m, 25000.0000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 28000.00m, 25000.0000m, 63, 26000.0000m, 25000.0000m, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.00m, 1m, "E003", new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes", "Forwarded to HR", "MC003", 3, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 63 },
                    { "MB004", 10666.67m, 32200.0000m, 30000.0000m, new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 32000.00m, 30000.0000m, 66, 32200.0000m, 30000.0000m, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200.00m, 2m, "E004", new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes", "All verified", "MC004", 3, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 66 },
                    { "MB005", 12000.00m, 36100.0000m, 33000.0000m, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 36000.00m, 33000.0000m, 69, 36100.0000m, 33000.0000m, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3100.00m, 3m, "E005", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yes", "Checked and finalized", "MC005", 3, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 69 }
                });

            migrationBuilder.InsertData(
            table: "NomineeInformations",
            columns: new[]
                {
                    "NomineeID", "Name", "Occupation", "Relation",
                    "Age", "Address", "Percentage", "Flag", "EmployeeID"
                },
                values: new object[,]
                {
            { "NOM001", "Robert", "DOE", "Brother", 25, "456 Nominee Rd, Dhaka", 10.5, "ABC", "E001" },
            { "NOM002", "Sophia Khan", "Teacher", "Sister", 30, "123 Nominee Ln, Chattogram", 15.0, "DEF", "E002" },
            { "NOM003", "Arif Rahman", "Engineer", "Cousin", 28, "789 Nominee Ave, Sylhet", 20.0, "GHI", "E003" },
            { "NOM004", "Nusrat Jahan", "Doctor", "Wife", 35, "321 Nominee Blvd, Rajshahi", 25.0, "JKL", "E004" },
            { "NOM005", "Hasan Ali", "Banker", "Father", 60, "654 Nominee St, Barisal", 30.0, "MNO", "E005" }
            });

            migrationBuilder.InsertData(
            table: "ChildrenInformations",
            columns: new[]
            {
                "ChildID", "ChildrenName", "DateOfBirth", "Age", "Gender",
                "BloodGroup", "MaritalStatus", "EmployeeID", "Flag"
            },
            values: new object[,]
            {
            { "CHILD001", "Alice Doe", new DateTime(2015, 6, 15), 9, "Female", "B+", "Married", "E001", "ABC" },
            { "CHILD002", "Michael Smith", new DateTime(2012, 3, 22), 12, "Male", "A+", "Single", "E002", "DEF" },
            { "CHILD003", "Emma Johnson", new DateTime(2010, 8, 10), 13, "Female", "O-", "Single", "E003", "GHI" },
            { "CHILD004", "Liam Brown", new DateTime(2016, 11, 5), 8, "Male", "AB+", "Single", "E004", "JKL" },
            { "CHILD005", "Olivia Davis", new DateTime(2013, 1, 17), 11, "Female", "B-", "Single", "E005", "MNO" }
             });

            migrationBuilder.InsertData(
            table: "SpouseInformations",
            columns: new[]
            {
                "SpouseID", "SpouseName", "Occupation", "DateOfBirth",
                "BloodGroup", "EmployeeID"
            },
            values: new object[,]
            {
                { "SPOUSE001", "Jane Doe", "HouseWife", new DateTime(2015, 6, 15), "B-", "E001" },
                { "SPOUSE002", "Amina Begum", "Nurse", new DateTime(1990, 4, 12), "A+", "E002" },
                { "SPOUSE003", "Tariq Islam", "Software Engineer", new DateTime(1988, 9, 30), "O+", "E003" },
                { "SPOUSE004", "Farzana Ahmed", "Lecturer", new DateTime(1992, 1, 25), "AB-", "E004" },
                { "SPOUSE005", "Mehnaz Sultana", "Entrepreneur", new DateTime(1991, 7, 8), "B+", "E005" }
            });

        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalaryGrades",
                keyColumn: "SalaryGradeID",
                keyValue: "SG001");

            migrationBuilder.DeleteData(
                table: "SalaryGrades",
                keyColumn: "SalaryGradeID",
                keyValue: "SG002");

            migrationBuilder.DeleteData(
                table: "SalaryGrades",
                keyColumn: "SalaryGradeID",
                keyValue: "SG003");

            migrationBuilder.DeleteData(
                table: "SalaryGrades",
                keyColumn: "SalaryGradeID",
                keyValue: "SG004");

            migrationBuilder.DeleteData(
                table: "SalaryGrades",
                keyColumn: "SalaryGradeID",
                keyValue: "SG005");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: "G001");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: "G002");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: "G003");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: "G004");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeID",
                keyValue: "G005");
        }
    }
}
