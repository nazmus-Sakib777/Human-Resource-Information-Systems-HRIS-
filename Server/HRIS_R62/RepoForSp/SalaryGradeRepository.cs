using HRIS_R62.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62.RepoForSp
{
    public class SalaryGradeRepository : ISalaryGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryGradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(SalaryGrade grade)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC spInsertSalaryGrade @SalaryGradeID = {0}, @GradeName = {1}, @GradeStatus = {2}, @RuleName = {3}, @EffectiveDate = {4}, @GradeID = {5}",
                grade.SalaryGradeID,
                grade.GradeName,
                grade.GradeStatus,
                grade.RuleName,
                grade.EffectiveDate,
                grade.GradeID
            );
        }
    }
}
