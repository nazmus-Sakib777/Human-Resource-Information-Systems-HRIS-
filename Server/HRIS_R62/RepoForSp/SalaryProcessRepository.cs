using HRIS_R62.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class SalaryProcessRepository : ISalaryProcessRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryProcessRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(SalaryProcess process)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC spInsertSalaryProcess " +
                "@ProcessID = {0}, @MonthNo = {1}, @YearNo = {2}, @FromDate = {3}, @ToDate = {4}, " +
                "@SalaryHeadName = {5}, @Amount = {6}, @Type = {7}, @ProcessDate = {8}, @ProcessedBy = {9}, " +
                "@EmployeeID = {10}, @SalaryEntryID = {11}",
                process.ProcessID,
                process.MonthNo,
                process.YearNo,
                process.FromDate,
                process.ToDate,
                process.SalaryHeadName,
                process.Amount,
                process.Type,
                process.ProcessDate,
                process.ProcessedBy,
                process.EmployeeID,
                process.SalaryEntryID
            );
        }
    }
}
