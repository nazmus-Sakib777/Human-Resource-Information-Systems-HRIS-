using HRIS_R62.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class FoodChargeRepository : IFoodChargeRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodChargeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertFoodChargeAsync(FoodCharge charge)
        {
            var sql = "EXEC sp_InsertFoodCharge @FoodChargeID, @ChargeDate, @ChargeAmount, " +
                      "@ChargeType, @Status, @EntryDate, @EntryUser, @EmployeeID";

            var parameters = new[]
            {
            new SqlParameter("@FoodChargeID", charge.FoodChargeID),
            new SqlParameter("@ChargeDate", charge.ChargeDate),
            new SqlParameter("@ChargeAmount", charge.ChargeAmount),
            new SqlParameter("@ChargeType", charge.ChargeType),
            new SqlParameter("@Status", charge.Status),
            new SqlParameter("@EntryDate", charge.EntryDate),
            new SqlParameter("@EntryUser", charge.EntryUser),
            new SqlParameter("@EmployeeID", charge.EmployeeID),
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
