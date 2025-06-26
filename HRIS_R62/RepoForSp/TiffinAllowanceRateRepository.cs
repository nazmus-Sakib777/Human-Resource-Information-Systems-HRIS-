using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class TiffinAllowanceRateRepository : ITiffinAllowanceRateRepository
    {
        private readonly ApplicationDbContext _context;

        public TiffinAllowanceRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertTiffinAllowanceRateAsync(TiffinAllowanceRate tiffinAllowanceRate)
        {
            var sql = "EXEC sp_InsertTiffinAllowanceRate @TiffinAllowanceRateID, @RateInTaka, @DesignationID";

            var parameters = new[]
            {
            new SqlParameter("@TiffinAllowanceRateID", tiffinAllowanceRate.TiffinAllowanceRateID),
            new SqlParameter("@RateInTaka", tiffinAllowanceRate.RateInTaka),
            new SqlParameter("@DesignationID", tiffinAllowanceRate.DesignationID!)  
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
