using KantineApp.Models;

namespace KantineApp.Repository
{
    public interface IWeeklyOfferRepository
    {
        List<WeeklyOffer> GetAll();
        WeeklyOffer? Get(int id);
        WeeklyOffer? GetCurrentOffer();
        WeeklyOffer Add(WeeklyOffer offer);
        WeeklyOffer Update(WeeklyOffer offer);
        WeeklyOffer? Delete(int id);
    }
}