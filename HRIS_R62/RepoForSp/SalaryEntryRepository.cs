using HRIS_R62.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class SalaryEntryRepository : ISalaryEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(SalaryEntry entry)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC spInsertSalaryEntry @SalaryEntryID = {0}, @ApplyDate = {1}, @SalaryHeadName = {2}, @Amount = {3}, @EmployeeID = {4}",
                entry.SalaryEntryID,
                entry.ApplyDate,
                entry.SalaryHeadName,
                entry.Amount,
                entry.EmployeeID
            );
        }
    }
}
