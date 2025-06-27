using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class FestivalBonusRepository : IFestivalBonusRepository
    {
        private readonly ApplicationDbContext _context;

        public FestivalBonusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertFestivalBonusAsync(FestivalBonus bonus)
        {
            var sql = "EXEC sp_InsertFestivalBonus @FestivalBonusID, @FestivalName, " +
                      "@PercentageBelowOneYear, @PercentageAfterOneYear, @BonusEligibilityCheck, " +
                      "@FestivalBonusDate, @EffectiveFrom, @EffectiveTo, @LastUpdated, @UpdatedBy, @EmployeeID";

            var parameters = new[]
            {
            new SqlParameter("@FestivalBonusID", bonus.FestivalBonusID),
            new SqlParameter("@FestivalName", bonus.FestivalName),
            new SqlParameter("@PercentageBelowOneYear", bonus.PercentageBelowOneYear),
            new SqlParameter("@PercentageAfterOneYear", bonus.PercentageAfterOneYear),
            new SqlParameter("@BonusEligibilityCheck", bonus.BonusEligibilityCheck),
            new SqlParameter("@FestivalBonusDate", bonus.FestivalBonusDate),
            new SqlParameter("@EffectiveFrom", bonus.EffectiveFrom),
            new SqlParameter("@EffectiveTo", bonus.EffectiveTo),
            new SqlParameter("@LastUpdated", bonus.LastUpdated),
            new SqlParameter("@UpdatedBy", bonus.UpdatedBy),
            new SqlParameter("@EmployeeID", bonus.EmployeeID),
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
