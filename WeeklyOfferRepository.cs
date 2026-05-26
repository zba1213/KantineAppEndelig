using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    public class WeeklyOfferRepository : IWeeklyOfferRepository
    {
        private readonly KantineDbContext _context;

        public WeeklyOfferRepository(KantineDbContext context)
        {
            _context = context;
        }

        public List<WeeklyOffer> GetAll() => _context.WeeklyOffers.ToList();
        public WeeklyOffer? Get(int id) => _context.WeeklyOffers.Find(id);

        public WeeklyOffer? GetCurrentOffer()
        {
            var today = DateTime.Today;
            return _context.WeeklyOffers.FirstOrDefault(o => o.ValidFrom <= today && o.ValidTo >= today);
        }

        public WeeklyOffer Add(WeeklyOffer offer)
        {
            _context.WeeklyOffers.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        public WeeklyOffer Update(WeeklyOffer offer)
        {
            _context.WeeklyOffers.Update(offer);
            _context.SaveChanges();
            return offer;
        }

        public WeeklyOffer? Delete(int id)
        {
            var offer = _context.WeeklyOffers.Find(id);
            if (offer != null)
            {
                _context.WeeklyOffers.Remove(offer);
                _context.SaveChanges();
            }
            return offer;
        }
    }
}