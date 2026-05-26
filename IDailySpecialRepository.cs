using KantineApp.Models;

namespace KantineApp.Repository
{
    public interface IDailySpecialRepository
    {
        List<DailySpecial> GetAll();
        DailySpecial? Get(int id);
        DailySpecial? GetByDate(DateTime date);
        DailySpecial Add(DailySpecial dailySpecial);
        DailySpecial Update(DailySpecial dailySpecial);
        DailySpecial? Delete(int id);
    }
}