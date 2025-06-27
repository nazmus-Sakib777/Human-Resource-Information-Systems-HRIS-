using HRIS_R62.Models;

namespace HRIS_R62.RepoForSp
{
    public interface IFoodChargeRepository
    {
        Task InsertFoodChargeAsync(FoodCharge charge);
    }
}
