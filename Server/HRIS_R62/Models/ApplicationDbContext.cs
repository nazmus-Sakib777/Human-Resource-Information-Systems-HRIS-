using HRIS_R62.DTOforSp;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;


namespace HRIS_R62.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AttendanceBonus> AttendanceBonus { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<BonusRecord> BonusRecords { get; set; }
        public DbSet<CareerHistory> CareerHistories { get; set; }
        public DbSet<ChildrenInformation> ChildrenInformations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactPersonInformation> ContactPersonInformations { get; set; }
        public DbSet<DateWiseOfficeTime> DateWiseOfficeTimes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<DisciplinaryAction> DisciplinaryActions { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<EarlyLeaveInformation> EarlyLeaveInformation { get; set; }
        public DbSet<EmployeeBenefits> EmployeeBenefits { get; set; }
        public DbSet<EmployeeComplaint> EmployeeComplaints { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public DbSet<OverTime> OverTimes { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeTax> EmployeeTaxes { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<FestivalBonus> FestivalBonuses { get; set; }
        public DbSet<FoodCharge> FoodCharges { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<HoliDayBillRate> HoliDayBillRates { get; set; }
        public DbSet<HoliDayEntitledEmployee> HoliDayEntitledEmployees { get; set; }
        public DbSet<HoliDayInformation> HoliDayInformations { get; set; }
        public DbSet<JobLeft> JobLefts { get; set; }
        public DbSet<LateApproval> LateApprovals { get; set; }
        public DbSet<LeaveApproval> LeaveApprovals { get; set; }
        public DbSet<LeaveEncashment> LeaveEncashments { get; set; }
        public DbSet<LeaveEncashmentRate> LeaveEncashmentRates { get; set; }
        public DbSet<LeaveRecord> LeaveRecords { get; set; }
        public DbSet<LineInformation> LineInformations { get; set; }
        public DbSet<ManualAttendance> ManualAttendances { get; set; }
        public DbSet<NightAllowance> NightAllowances { get; set; }
        public DbSet<NightAllowanceTime> NightAllowanceTimes { get; set; }
        public DbSet<NomineeInformation> NomineeInformations { get; set; }
        public DbSet<ProximityRecord> ProximityRecords { get; set; }
        public DbSet<SalaryDeduction> SalaryDeductions { get; set; }
        public DbSet<SalaryEntry> SalaryEntrys { get; set; }
        public DbSet<SalaryGrade> SalaryGrades { get; set; }
        public DbSet<SalaryProcess> SalaryProcesss { get; set; }
        public DbSet<SalaryRecord> SalaryRecords { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<ShiftEmployee> ShiftEmployees { get; set; }
        public DbSet<SpecialEmployee> SpecialEmployees { get; set; }
        public DbSet<SpouseInformation> SpouseInformations { get; set; }
        public DbSet<Suspend> Suspends { get; set; }
        public DbSet<TaxAmount> TaxAmounts { get; set; }
        public DbSet<TaxExempted> TaxExempteds { get; set; }
        public DbSet<TaxRule> TaxRules { get; set; }
        public DbSet<TiffinAllowanceRate> TiffinAllowanceRates { get; set; }
        public DbSet<TiffinAllowanceTime> TiffinAllowanceTimes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<MaternityBill> MaternityBills { get; set; }
        public DbSet<MaternityConfiguration> MaternityConfigurations { get; set; }
        public DbSet<ShiftTime> ShiftTimes { get; set; }
        public DbSet<AttendanceConfiguration> AttendanceConfigurations { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuss { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<LogFile> LogFiles { get; set; }

        //Added By Mofizul+Nokib
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttendanceDto>(entity =>
            {
                entity.HasNoKey();
            });

            //Nokib
            modelBuilder.Entity<MaternityBill>()
            .HasOne(bill => bill.MaternityConfiguration)
            .WithMany(config => config.MaternityBills)
            .HasForeignKey(bill => bill.MaternityConfigurationID)
            .OnDelete(DeleteBehavior.Cascade); // Or Restrict if you want soft protection
        }

        // Sproc Tofayel
        private readonly ApplicationDbContext _context;
        public async Task<int> AddAttendanceRecordAsync(AttendanceRecord attendance)
        {
            var parameters = new[]
            {
            new SqlParameter("@AttendanceRecordID", attendance.AttendanceRecordID),
            new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
            new SqlParameter("@InTime", attendance.InTime),
            new SqlParameter("@OutTime", attendance.OutTime),
            new SqlParameter("@OTStart", attendance.OTStart),
            new SqlParameter("@OTEnd", attendance.OTEnd),
            new SqlParameter("@TotalRegularHours", attendance.TotalRegularHours),
            new SqlParameter("@TotalOvertimeHours", attendance.TotalOvertimeHours),
            new SqlParameter("@DayType", attendance.DayType),
            new SqlParameter("@AttendanceConfigurationID", attendance.AttendanceConfigurationID),
            new SqlParameter("@AttendanceStatusID", attendance.AttendanceStatusID)
        };

            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_InsertAttendanceRecord @AttendanceRecordID, @AttendanceDate, @InTime, @OutTime, @OTStart, @OTEnd, @TotalRegularHours, @TotalOvertimeHours, @DayType, @AttendanceConfigurationID, @AttendanceStatusID", parameters);
        }

        public async Task<int> UpdateAttendanceRecordAsync(AttendanceRecord attendance)
        {
            var parameters = new[]
            {
            new SqlParameter("@AttendanceRecordID", attendance.AttendanceRecordID),
            new SqlParameter("@AttendanceDate", attendance.AttendanceDate),
            new SqlParameter("@InTime", attendance.InTime),
            new SqlParameter("@OutTime", attendance.OutTime),
            new SqlParameter("@OTStart", attendance.OTStart),
            new SqlParameter("@OTEnd", attendance.OTEnd),
            new SqlParameter("@TotalRegularHours", attendance.TotalRegularHours),
            new SqlParameter("@TotalOvertimeHours", attendance.TotalOvertimeHours),
            new SqlParameter("@DayType", attendance.DayType),
            new SqlParameter("@AttendanceConfigurationID", attendance.AttendanceConfigurationID),
            new SqlParameter("@AttendanceStatusID", attendance.AttendanceStatusID)
        };

            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateAttendanceRecord @AttendanceRecordID, @AttendanceDate, @InTime, @OutTime, @OTStart, @OTEnd, @TotalRegularHours, @TotalOvertimeHours, @DayType, @AttendanceConfigurationID, @AttendanceStatusID", parameters);
        }

        public async Task<int> DeleteAttendanceRecordAsync(string attendanceRecordID)
        {
            var parameter = new SqlParameter("@AttendanceRecordID", attendanceRecordID);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteAttendanceRecord @AttendanceRecordID", parameter);
        }


        //Sarah Sproc

        public void InsertDesignation(Designation designation)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@DesignationID", designation.DesignationID);
            SqlParameter sqlName = new SqlParameter("@DesignationName", designation.DesignationName);
            SqlParameter sqlNameLocal = new SqlParameter("@DesignationNameLocal", designation.DesignationNameLocal);
            this.Database.ExecuteSqlRaw("EXEC sp_InsertDesignation @DesignationID,@DesignationName,@DesignationNameLocal", sqlId, sqlName, sqlNameLocal);
        }
        public void InsertDivision(Division division)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@DivisionID", division.DivisionID);
            SqlParameter sqlName = new SqlParameter("@DivisionName", division.DivisionName);
            SqlParameter sqlShortName = new SqlParameter("@DivisionShortName", division.DivisionShortName);
            SqlParameter sqlNameLocal = new SqlParameter("@DivisionNameLocal", division.DivisionNameLocal);
            this.Database.ExecuteSqlRaw("EXEC sp_InsertDivision @DivisionID,@DivisionName,@DivisionShortName,@DivisionNameLocal", sqlId, sqlName, sqlShortName, sqlNameLocal);
        }
        public void InsertSection(Sections sections)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@SectionsID", sections.SectionsID);
            SqlParameter sqlName = new SqlParameter("@SectionName", sections.SectionName);
            SqlParameter sqlShortName = new SqlParameter("@SectionShortName", sections.SectionShortName);
            SqlParameter sqlNameNative = new SqlParameter("@SectionNameNative", sections.SectionNameNative);
            SqlParameter sqlCmpName = new SqlParameter("@CompanyID", sections.CompanyID);
            this.Database.ExecuteSqlRaw("EXEC sp_InsertSection @SectionsID,@SectionName,@SectionShortName,@SectionNameNative,@CompanyID", sqlId, sqlName, sqlShortName, sqlNameNative, sqlCmpName);
        }
        public void InsertUnit(Unit unit)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@UnitID", unit.UnitID);
            SqlParameter sqlName = new SqlParameter("@UnitName", unit.UnitName);
            SqlParameter sqlCmpName = new SqlParameter("@CompanyID", unit.CompanyID);
            this.Database.ExecuteSqlRaw("EXEC sp_InsertUnit @UnitID,@UnitName,@CompanyID", sqlId, sqlName, sqlCmpName);
        }
        public void InsertDateWiseTime(DateWiseOfficeTime d)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@DateWiseOfficeTimeID", d.DateWiseOfficeTimeID);
            SqlParameter sqlName = new SqlParameter("@ShiftStartDateTime", d.ShiftStartDateTime);
            SqlParameter sqlCmpName = new SqlParameter("@ShiftEndDateTime", d.ShiftEndDateTime);
            SqlParameter sqlLunch = new SqlParameter("@ConsideredLunchHour", d.ConsideredLunchHour);
            SqlParameter sqlBreak = new SqlParameter("@BreakDuration", d.BreakDuration);
            //SqlParameter sqlempId = new SqlParameter("@EmployeeID", d.EmployeeID);
            this.Database.ExecuteSqlRaw("EXEC sp_InsertDateWiseOfficeTime @DateWiseOfficeTimeID,@ShiftStartDateTime,@ShiftEndDateTime,@ConsideredLunchHour,@BreakDuration", sqlId, sqlName, sqlCmpName, sqlLunch, sqlBreak);
        }

        public void InsertShiftEmployee(ShiftEmployee sh)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@ShiftEmployeeID", sh.ShiftEmployeeID);
            SqlParameter sqlName = new SqlParameter("@FromDate", sh.FromDate);
            SqlParameter sqlCmpName = new SqlParameter("@ToDate", sh.ToDate);
            //SqlParameter sqlempId = new SqlParameter("@EmployeeID", sh.EmployeeID);
            SqlParameter sqlBreak = new SqlParameter("@DateWiseOfficeTimeID", sh.DateWiseOfficeTimeID);

            this.Database.ExecuteSqlRaw("EXEC sp_InsertShiftEmployee @ShiftEmployeeID,@FromDate,@ToDate,@DateWiseOfficeTimeID", sqlId, sqlName, sqlCmpName, sqlBreak);
        }



        //Sakib Sproc

        public async Task InsertEmploymentTypeAsync(EmploymentType employmentType)
        {
            // Inserts EmploymentType itself
            var parameters = new[]
            {
            new SqlParameter("@EmploymentTypeID", employmentType.EmploymentTypeID),
            new SqlParameter("@EmploymentTypeName", employmentType.EmploymentTypeName)
            };

            await Database.ExecuteSqlRawAsync("EXEC sp_InsertEmploymentType @EmploymentTypeID, @EmploymentTypeName", parameters);

        }


        public async Task InsertShiftTimeAsync(ShiftTime shiftTime)
        {
            var parameters = new[]
            {
            new SqlParameter("@ShiftID", shiftTime.ShiftID),
            new SqlParameter("@ShiftName", shiftTime.ShiftName ?? (object)DBNull.Value),
            new SqlParameter("@ShiftStart", shiftTime.ShiftStart),
            new SqlParameter("@ShiftEnd", shiftTime.ShiftEnd),
            new SqlParameter("@StartDate", shiftTime.StartDate),
            new SqlParameter("@EndDate", shiftTime.EndDate),
            new SqlParameter("@ConsideredLunchHour", shiftTime.ConsideredLunchHour.HasValue ? (object)shiftTime.ConsideredLunchHour.Value : DBNull.Value),
            new SqlParameter("@BreakDuration", shiftTime.BreakDuration),
            new SqlParameter("@EmployeeID", shiftTime.EmployeeID ?? (object)DBNull.Value),
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertShiftTime @ShiftID, @ShiftName, @ShiftStart, @ShiftEnd, @StartDate, @EndDate, @ConsideredLunchHour, @BreakDuration, @EmployeeID",
                parameters);
        }


        public async Task InsertJobLeftAsync(JobLeft jobLeft)
        {
            var parameters = new[]
            {
            new SqlParameter("@JobLeftID", jobLeft.JobLeftID),
            new SqlParameter("@JobLeftDate", (object?)jobLeft.JobLeftDate ?? DBNull.Value),
            new SqlParameter("@JobLeftType", jobLeft.JobLeftType ?? (object)DBNull.Value),
            new SqlParameter("@LocalAreaClerance", jobLeft.LocalAreaClerance ?? (object)DBNull.Value),
            new SqlParameter("@LocalAreaRemarks", jobLeft.LocalAreaRemarks ?? (object)DBNull.Value),
            new SqlParameter("@ApprovedDate", (object?)jobLeft.ApprovedDate ?? DBNull.Value),
            new SqlParameter("@EntryUser", jobLeft.EntryUser ?? (object)DBNull.Value),
            new SqlParameter("@EmployeeID", jobLeft.EmployeeID ?? (object)DBNull.Value),
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertJobLeft @JobLeftID, @JobLeftDate, @JobLeftType, @LocalAreaClerance, @LocalAreaRemarks, @ApprovedDate, @EntryUser, @EmployeeID",
                parameters);
        }


        public async Task InsertSuspendAsync(Suspend suspend)
        {
            var parameters = new[]
            {
            new SqlParameter("@SuspendID", suspend.SuspendID),
            new SqlParameter("@EmployeeID", (object?)suspend.EmployeeID ?? DBNull.Value),
            new SqlParameter("@EmployeeName", suspend.EmployeeName),
            new SqlParameter("@EntryDate", suspend.EntryDate),
            new SqlParameter("@SuspendDate", (object?)suspend.SuspendDate ?? DBNull.Value),
            new SqlParameter("@LocalAreaClerance", suspend.LocalAreaClerance),
            new SqlParameter("@Release", suspend.Release),
            new SqlParameter("@Remarks", suspend.Remarks),
            new SqlParameter("@ApprovedDate", (object?)suspend.ApprovedDate ?? DBNull.Value),
            new SqlParameter("@ReleasedDate", (object?)suspend.ReleasedDate ?? DBNull.Value),
            new SqlParameter("@EntryUser", suspend.EntryUser)
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertSuspend @SuspendID, @EmployeeID, @EmployeeName, @EntryDate, @SuspendDate, @LocalAreaClerance, @Release, @Remarks, @ApprovedDate, @ReleasedDate, @EntryUser",
                parameters);
        }

        public async Task InsertSpecialEmployeeAsync(SpecialEmployee specialEmployee)
        {
            var parameters = new[]
            {
            new SqlParameter("@SpecialEmployeeID", specialEmployee.SpecialEmployeeID),
            new SqlParameter("@FromDate", (object?)specialEmployee.FromDate ?? DBNull.Value),
            new SqlParameter("@ToDate", (object?)specialEmployee.ToDate ?? DBNull.Value),
            new SqlParameter("@AttendanceType", specialEmployee.AttendanceType ?? (object)DBNull.Value),
            new SqlParameter("@EmployeeID", (object?)specialEmployee.EmployeeID ?? DBNull.Value),
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertSpecialEmployee @SpecialEmployeeID, @FromDate, @ToDate, @AttendanceType, @EmployeeID",
                parameters);
        }

        /*--Jannat Store proc Method*/
        public void InsertLineInformations(LineInformation lineInformations)
        {
            SqlParameter sqlId = new SqlParameter("@LineID", lineInformations.LineID);
            SqlParameter sqlName = new SqlParameter("@LineName", lineInformations.LineName);
            SqlParameter sqlEntryDate = new SqlParameter("@EntryDate", lineInformations.EntryDate);
            SqlParameter sqlUID = new SqlParameter("@UnitID", lineInformations.UnitID);
            SqlParameter sqlBID = new SqlParameter("@BuildingID", lineInformations.BuildingID);
            SqlParameter sqlSID = new SqlParameter("@SectionsID", lineInformations.SectionsID);
            SqlParameter sqlCID = new SqlParameter("@CompanyID", lineInformations.CompanyID);
            SqlParameter sqlDID = new SqlParameter("@DivisionID", lineInformations.DivisionID);



            this.Database.ExecuteSqlRaw("exec sp_InsertLineInfo  @LineID, @LineName, @EntryDate, @UnitID, @BuildingID, @SectionsID, @CompanyID, @DivisionID", sqlId, sqlName, sqlEntryDate, sqlUID, sqlBID, sqlSID, sqlCID, sqlDID);
        }

        //--Tawhid Store Proc Method

        public async Task InsertHolidayBillRateAsync(HoliDayBillRate holiDayBillRate)
        {
            var parameters = new[]
            {
            new SqlParameter("@HoliDayBillRateID", holiDayBillRate.HoliDayBillRateID),
            new SqlParameter("@SerialNumber", holiDayBillRate.SerialNumber),
            new SqlParameter("@SalaryMinimum", holiDayBillRate.SalaryMinimum),
            new SqlParameter("@SalaryMaximum", holiDayBillRate.SalaryMaximum),
            new SqlParameter("@HoliDayBillRateValue", holiDayBillRate.HoliDayBillRateValue),
            new SqlParameter("@EmployeeID", holiDayBillRate.EmployeeID)
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertHoliDayBillRate @HoliDayBillRateID, @SerialNumber, @SalaryMinimum, @SalaryMaximum, @HoliDayBillRateValue, @EmployeeID",
                parameters
            );
        }

        public async Task InsertHolidayEntitledEmployeeAsync(HoliDayEntitledEmployee employee)
        {
            var parameters = new[]
            {
            new SqlParameter("@HoliDayEntitledEmployeeID", employee.HoliDayEntitledEmployeeID),
            new SqlParameter("@AttendanceDate", employee.AttendanceDate),
            new SqlParameter("@AttendanceStatus", employee.AttendanceStatus ?? (object)DBNull.Value),
            new SqlParameter("@LocalAreaClerance", employee.LocalAreaClerance ?? (object)DBNull.Value),
            new SqlParameter("@LocalAreaRemarks", employee.LocalAreaRemarks ?? (object)DBNull.Value),
            new SqlParameter("@ApprovedDate", employee.ApprovedDate),
            new SqlParameter("@EntryUser", employee.EntryUser ?? (object)DBNull.Value),
            new SqlParameter("@EmployeeID", employee.EmployeeID)
        };

            await Database.ExecuteSqlRawAsync(
                "EXEC usp_InsertHoliDayEntitledEmployee @HoliDayEntitledEmployeeID, @AttendanceDate, @AttendanceStatus, @LocalAreaClerance, @LocalAreaRemarks, @ApprovedDate, @EntryUser, @EmployeeID",
                parameters
            );
        }

        public async Task InsertHolidayainformationAsync(HoliDayInformation holiDayInformation)
        {
            var parameters = new[]
            {
            new SqlParameter("@HoliDayInformationID", holiDayInformation.HoliDayInformationID ?? (object)DBNull.Value),
            new SqlParameter("@FromDate", holiDayInformation.FromDate),
            new SqlParameter("@EndDate", holiDayInformation.EndDate),
            new SqlParameter("@EventType", holiDayInformation.EventType ?? (object)DBNull.Value),
            new SqlParameter("@EventName", holiDayInformation.EventName ?? (object)DBNull.Value),
            new SqlParameter("@Remarks", holiDayInformation.Remarks ?? (object)DBNull.Value),
            new SqlParameter("@EntryUser", holiDayInformation.EntryUser ?? (object)DBNull.Value),
            new SqlParameter("@EmployeeID", holiDayInformation.EmployeeID ?? (object)DBNull.Value)
        };

            await Database.ExecuteSqlRawAsync(
                "EXEC usp_InsertHoliDayInformation @HoliDayInformationID, @FromDate, @EndDate, @EventType, @EventName, @Remarks, @EntryUser, @EmployeeID",
                parameters
            );
        }

        public async Task InsertEmployeeBenefitAsync(EmployeeBenefits benefit)
        {
            var parameters = new[]
            {
            new SqlParameter("@BenefitID", benefit.BenefitID),
            new SqlParameter("@EmployeeID", benefit.EmployeeID ?? (object)DBNull.Value),
            new SqlParameter("@BenefitDate", benefit.BenefitDate ?? (object)DBNull.Value),
            new SqlParameter("@BenefitAmount", benefit.BenefitAmount),
            new SqlParameter("@BenefitType", benefit.BenefitType ?? (object)DBNull.Value),
            new SqlParameter("@BenefitActivationDate", benefit.BenefitActivationDate ?? (object)DBNull.Value),
            new SqlParameter("@PreviousNetSalary", benefit.PreviousNetSalary),
            new SqlParameter("@NewNetSalary", benefit.NewNetSalary),
            new SqlParameter("@SalaryStepID", benefit.SalaryStepID ?? (object)DBNull.Value),
            new SqlParameter("@GradeID", benefit.GradeID ?? (object)DBNull.Value),
            new SqlParameter("@GrossSalary", benefit.GrossSalary),
            new SqlParameter("@BasicSalary", benefit.BasicSalary),
            new SqlParameter("@HouseRent", benefit.HouseRent),
            new SqlParameter("@MedicalAllowance", benefit.MedicalAllowance),
            new SqlParameter("@ConveyanceAllowance", benefit.ConveyanceAllowance),
            new SqlParameter("@LunchAllowance", benefit.LunchAllowance),
            new SqlParameter("@OtherAllowance", benefit.OtherAllowance),
            new SqlParameter("@SalaryRecordID", benefit.SalaryRecordID ?? (object)DBNull.Value),
            new SqlParameter("@CashIncentive", benefit.CashIncentive),
            new SqlParameter("@LocalAreaClerance", benefit.LocalAreaClerance ?? (object)DBNull.Value),
            new SqlParameter("@LocalAreaRemarks", benefit.LocalAreaRemarks ?? (object)DBNull.Value),
            new SqlParameter("@ApprovalDate", benefit.ApprovalDate ?? (object)DBNull.Value),
            new SqlParameter("@EntryUser", benefit.EntryUser ?? (object)DBNull.Value),
            new SqlParameter("@SalaryGradeID", benefit.SalaryGradeID ?? (object)DBNull.Value)
        };

            await Database.ExecuteSqlRawAsync(
                "EXEC usp_InsertEmployeeBenefits @BenefitID, @EmployeeID, @BenefitDate, @BenefitAmount, @BenefitType, @BenefitActivationDate, " +
                "@PreviousNetSalary, @NewNetSalary, @SalaryStepID, @GradeID, @GrossSalary, @BasicSalary, @HouseRent, @MedicalAllowance, " +
                "@ConveyanceAllowance, @LunchAllowance, @OtherAllowance, @SalaryRecordID, @CashIncentive, @LocalAreaClerance, " +
                "@LocalAreaRemarks, @ApprovalDate, @EntryUser, @SalaryGradeID",
                parameters
            );
        }

        //Tasrif

        public void InsertManualAtt(ManualAttendance d)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@ManualAttendanceID", d.ManualAttendanceID);
            SqlParameter sqldate = new SqlParameter("@AttendanceDate", d.AttendanceDate);
            SqlParameter sqltime = new SqlParameter("@AttendanceTime", d.AttendanceTime);
            SqlParameter sqlEntDate = new SqlParameter("@EntryDate", d.EntryDate);
            SqlParameter sqlReason = new SqlParameter("@Reason", d.Reason);
            SqlParameter sqlLocalClear = new SqlParameter("@LocalAreaClerance", d.LocalAreaClerance);
            SqlParameter sqlLocalRemarks = new SqlParameter("@LocalAreaRemarks", d.LocalAreaRemarks);
            SqlParameter sqlAppDate = new SqlParameter("@ApprovedDate", d.ApprovedDate);
            SqlParameter sqlEntUser = new SqlParameter("@EntryUser", d.EntryUser);
            SqlParameter sqlOutTime = new SqlParameter("@OutTime", d.OutTime);
            SqlParameter sqlReam = new SqlParameter("@Remarks", d.Remarks);
            SqlParameter sqlEmpId = new SqlParameter("@EmployeeID", d.EmployeeID);
            this.Database.ExecuteSqlRaw("EXEC InsertManualAttendance @ManualAttendanceID,@AttendanceDate,@AttendanceTime,@EntryDate,@Reason,@LocalAreaClerance,@LocalAreaRemarks,@ApprovedDate,@EntryUser,@OutTime,@Remarks,@EmployeeID", sqlId, sqldate, sqltime, sqlEntDate, sqlReason, sqlLocalClear, sqlLocalRemarks, sqlAppDate, sqlEntUser, sqlOutTime, sqlReam, sqlEmpId);
        }
        public void InsertLateApp(LateApproval d)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@AttendanceStatusID", d.LateApprovalID);
            SqlParameter sqldate = new SqlParameter("@StatusName", d.LateDate);
            SqlParameter sqltime = new SqlParameter("@LateTime", d.LateTime);
            SqlParameter sqlEntDate = new SqlParameter("@LateEntryDate", d.LateEntryDate);
            SqlParameter sqlReason = new SqlParameter("@LateReason", d.LateReason);
            SqlParameter sqlLocalClear = new SqlParameter("@LocalAreaClerance", d.LocalAreaClerance);
            SqlParameter sqlLocalRemarks = new SqlParameter("@LocalAreaRemarks", d.LocalAreaRemarks);
            SqlParameter sqlAppDate = new SqlParameter("@ApprovedDate", d.ApprovedDate);
            SqlParameter sqlEntUser = new SqlParameter("@EntryUser", d.EntryUser);
            SqlParameter sqlEmpId = new SqlParameter("@EmployeeID", d.EmployeeID);
            this.Database.ExecuteSqlRaw("EXEC InsertLateApproval @LateApprovalID,@LateDate,@LateTime,@LateEntryDate,@LateReason,@LocalAreaClerance,@LocalAreaRemarks,@ApprovedDate,@EntryUser,@EmployeeID", sqlId, sqldate, sqltime, sqlEntDate, sqlReason, sqlLocalClear, sqlLocalRemarks, sqlAppDate, sqlEntUser, sqlEmpId);
        }

        public void InsertEarlyLeaveapp(EarlyLeaveInformation d)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@EarlyLeaveInformationID", d.EarlyLeaveInformationID);
            SqlParameter sqldate = new SqlParameter("@LeaveDate", d.LeaveDate);
            SqlParameter sqltime = new SqlParameter("@LeaveType", d.LeaveType);
            SqlParameter sqlEntDate = new SqlParameter("@LeaveTime", d.LeaveTime);
            SqlParameter sqlEmpId = new SqlParameter("@EmployeeID", d.EmployeeID);
            this.Database.ExecuteSqlRaw("EXEC InsertEarlyLeaveInformation @EarlyLeaveInformationID,@LeaveDate,@LeaveType,@LeaveTime,@EmployeeID", sqlId, sqldate, sqltime, sqlEntDate, sqlEmpId);
        }

        public void InsertAttendancestatus(AttendanceStatus d)/*--Store proc Method*/
        {
            SqlParameter sqlId = new SqlParameter("@AttendanceStatusID", d.AttendanceStatusID);
            SqlParameter sqlstatusname = new SqlParameter("@StatusName", d.StatusName);
            SqlParameter sqlstatusshortn = new SqlParameter("@StatusShortName", d.StatusShortName);
            this.Database.ExecuteSqlRaw("EXEC InsertAttendanceStatuss @AttendanceStatusID,@StatusName,@StatusShortName", sqlId, sqlstatusname, sqlstatusshortn);
        }

        //Bibi Amana
        public async Task<int> AddBuildingUsingSP(Building building)
        {
            return await Database.ExecuteSqlRawAsync("EXEC sp_AddBuilding @p0, @p1, @p2, @p3, @p4",
                building.BuildingID, building.Floor, building.RoomNumber, building.Name, building.CompanyID);
        }

        public async Task<int> AddCompanyUsingSP(Company company)
        {
            return await Database.ExecuteSqlRawAsync("EXEC sp_AddCompany @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                company.CompanyID, company.CompanyName, company.CompanyShortName,
                company.CompanyNameLocal, company.CompanyAddress,
                company.PhoneNumber, company.FaxNumber, company.Email);
        }


    }
}
