using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class TiffinAllowanceTimeRepository : ITiffinAllowanceTimeRepository
    {
        private readonly ApplicationDbContext _context;

        public TiffinAllowanceTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertTiffinAllowanceTimeAsync(TiffinAllowanceTime tiffinAllowanceTime)
        {
            var sql = "EXEC sp_InsertTiffinAllowanceTime @TiffinAllowanceID, @AllowanceDate, @AllowanceType, @Time, @EmploymentTypeID";

            var parameters = new[]
            {
        new SqlParameter("@TiffinAllowanceID", tiffinAllowanceTime.TiffinAllowanceID),
        new SqlParameter("@AllowanceDate", tiffinAllowanceTime.AllowanceDate.ToDateTime(TimeOnly.MinValue)),
        new SqlParameter("@AllowanceType", tiffinAllowanceTime.AllowanceType),
        new SqlParameter("@Time", tiffinAllowanceTime.Time.ToTimeSpan()),
        new SqlParameter("@EmploymentTypeID", tiffinAllowanceTime.EmploymentTypeID!)  
    };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
