using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class NightAllowanceRepository : INightAllowanceRepository
    {
        private readonly ApplicationDbContext _context;

        public NightAllowanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertNightAllowanceAsync(NightAllowance model)
        {
            var sql = "EXEC sp_InsertNightAllowance @NightAllowanceID, @SalaryMinimum, @SalaryMaximum, @NightAllowanceRate, @EmploymentTypeID";

            var parameters = new[]
            {
            new SqlParameter("@NightAllowanceID", model.NightAllowanceID),
            new SqlParameter("@SalaryMinimum", model.SalaryMinimum),
            new SqlParameter("@SalaryMaximum", model.SalaryMaximum),
            new SqlParameter("@NightAllowanceRate", model.NightAllowanceRate),
            new SqlParameter("@EmploymentTypeID", model.EmploymentTypeID)
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
