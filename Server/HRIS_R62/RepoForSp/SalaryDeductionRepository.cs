using HRIS_R62.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class SalaryDeductionRepository : ISalaryDeductionRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryDeductionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(SalaryDeduction deduction)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC spInsertSalaryDeduction @SalaryDeductionID = {0}, @Amount = {1}, @DeductionDate = {2}, @ActivationDate = {3}, @Reason = {4}, @LocalAreaClerance = {5}, @LocalAreaRemarks = {6}, @ApprovedDate = {7}, @EntryUser = {8}, @EntryDate = {9}, @EmployeeID = {10}",
                deduction.SalaryDeductionID,
                deduction.Amount,
                deduction.DeductionDate,
                deduction.ActivationDate,
                deduction.Reason,
                deduction.LocalAreaClerance,
                deduction.LocalAreaRemarks,
                deduction.ApprovedDate,
                deduction.EntryUser,
                deduction.EntryDate,
                deduction.EmployeeID
            );
        }
    }
}
