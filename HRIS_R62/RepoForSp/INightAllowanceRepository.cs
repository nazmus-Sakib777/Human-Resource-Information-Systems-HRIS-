using HRIS_R62.Models;

namespace HRIS_R62.RepoForSp
{
    public interface INightAllowanceRepository
    {
        Task InsertNightAllowanceAsync(NightAllowance nightAllowance);
    }

}
