using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class BonusRecordRepository : IBonusRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public BonusRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertBonusRecordAsync(BonusRecord record)
        {
            var sql = "EXEC sp_InsertBonusRecord @BonusRecordID, @BonusDate, @JoiningDate, " +
                      "@BasicSalary, @HouseRent, @MedicalAllowance, @ConveyanceAllowance, " +
                      "@OtherAllowance, @GrossSalary, @BonusPercent, @BonusAmount, " +
                      "@FestivalName, @RevenueStampAmount, @NetPayableAmount, @EmployeeID";

            var parameters = new[]
            {
            new SqlParameter("@BonusRecordID", record.BonusRecordID),
            new SqlParameter("@BonusDate", record.BonusDate.ToDateTime(TimeOnly.MinValue)),
            new SqlParameter("@JoiningDate", record.JoiningDate.ToDateTime(TimeOnly.MinValue)),
            new SqlParameter("@BasicSalary", record.BasicSalary),
            new SqlParameter("@HouseRent", record.HouseRent),
            new SqlParameter("@MedicalAllowance", record.MedicalAllowance),
            new SqlParameter("@ConveyanceAllowance", record.ConveyanceAllowance),
            new SqlParameter("@OtherAllowance", record.OtherAllowance),
            new SqlParameter("@GrossSalary", record.GrossSalary),
            new SqlParameter("@BonusPercent", record.BonusPercent),
            new SqlParameter("@BonusAmount", record.BonusAmount),
            new SqlParameter("@FestivalName", record.FestivalName),
            new SqlParameter("@RevenueStampAmount", record.RevenueStampAmount),
            new SqlParameter("@NetPayableAmount", record.NetPayableAmount),
            new SqlParameter("@EmployeeID", record.EmployeeID),
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }

}
