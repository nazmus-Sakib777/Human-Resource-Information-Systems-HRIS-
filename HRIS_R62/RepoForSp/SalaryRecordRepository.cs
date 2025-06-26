using HRIS_R62.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class SalaryRecordRepository : ISalaryRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(SalaryRecord record)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spInsertSalaryRecord " +
                "@SalaryRecordID = {0}, @SalaryStartDate = {1}, @SalaryEndDate = {2}, @JoiningDate = {3}, " +
                "@MonthDays = {4}, @PunchDays = {5}, @TotalHoliDay = {6}, @TotalLeave = {7}, " +
                "@WorkingDays = {8}, @Absenteeism = {9}, @Gross = {10}, @ActualGross = {11}, " +
                "@Basic = {12}, @HouseRent = {13}, @MedicalAllowance = {14}, @MobileAllowance = {15}, " +
                "@OtherAllowances = {16}, @LunchAllowance = {17}, @Tax = {18}, @OtherDeduction = {19}, " +
                "@OTHours = {20}, @OTAmount = {21}, @ByBankAmount = {22}, @ByCashAmount = {23}, " +
                "@NetPayable = {24}, @ConveyanceAllowance = {25}, @AttendanceBonus = {26}, @SpecialAllowance = {27}, " +
                "@SalaryAdvance = {28}, @FoodCharge = {29}, @OTRate = {30}, @TiffinAllowance = {31}, @Arrear = {32}, " +
                "@SpecialBonus = {33}, @LeaveStatus = {34}, @HoliDayBillAmount = {35}, @NightBillAmount = {36}, " +
                "@SalaryID = {37}, @LunchBillAmount = {38}, @MobileBanking = {39}, @AccountNumber = {40}, " +
                "@BankName = {41}, @ProcessDate = {42}, @UnitID = {43}, @SectionID = {44}, " +
                "@EmploymentTypeID = {45}, @SalaryGradeID = {46}, @CompanyID = {47}, @DepartmentID = {48}, " +
                "@DesignationID = {49}, @GradeID = {50}",
                record.SalaryRecordID, record.SalaryStartDate, record.SalaryEndDate, record.JoiningDate,
                record.MonthDays, record.PunchDays, record.TotalHoliDay, record.TotalLeave,
                record.WorkingDays, record.Absenteeism, record.Gross, record.ActualGross,
                record.Basic, record.HouseRent, record.MedicalAllowance, record.MobileAllowance,
                record.OtherAllowances, record.LunchAllowance, record.Tax, record.OtherDeduction,
                record.OTHours, record.OTAmount, record.ByBankAmount, record.ByCashAmount,
                record.NetPayable, record.ConveyanceAllowance, record.AttendanceBonus, record.SpecialAllowance,
                record.SalaryAdvance, record.FoodCharge, record.OTRate, record.TiffinAllowance, record.Arrear,
                record.SpecialBonus, record.LeaveStatus, record.HoliDayBillAmount, record.NightBillAmount,
                record.SalaryID, record.LunchBillAmount, record.MobileBanking, record.AccountNumber,
                record.BankName, record.ProcessDate, record.UnitID, record.SectionID,
                record.EmploymentTypeID, record.SalaryGradeID, record.CompanyID, record.DepartmentID,
                record.DesignationID, record.GradeID
            );
        }
    }
}
