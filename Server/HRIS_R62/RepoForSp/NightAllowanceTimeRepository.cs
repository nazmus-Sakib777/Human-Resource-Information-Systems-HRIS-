using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class NightAllowanceTimeRepository : INightAllowanceTimeRepository
    {
        private readonly ApplicationDbContext _context;

        public NightAllowanceTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertNightAllowanceTimeAsync(NightAllowanceTime model)
        {
            var sql = "EXEC sp_InsertNightAllowanceTime @NightAllowanceTimeID, @StartDate, @EndDate, @AllowanceType, @NightHours, @NightMinutes, @EmploymentTypeID";

            var parameters = new[]
            {
            new SqlParameter("@NightAllowanceTimeID", model.NightAllowanceTimeID),
            new SqlParameter("@StartDate", model.StartDate),
            new SqlParameter("@EndDate", model.EndDate),
            new SqlParameter("@AllowanceType", model.AllowanceType),
            new SqlParameter("@NightHours", model.NightHours),
            new SqlParameter("@NightMinutes", model.NightMinutes),
            new SqlParameter("@EmploymentTypeID", model.EmploymentTypeID)
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
