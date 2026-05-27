using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    // Repository for managing WeeklyOffer entities in the database
    public class WeeklyOfferRepository : IWeeklyOfferRepository
    {
        private readonly KantineDbContext _context;

        // Constructor: injects the database context
        public WeeklyOfferRepository(KantineDbContext context)
        {
            _context = context;
        }

        // Returns all weekly offers from the database
        public List<WeeklyOffer> GetAll() => _context.WeeklyOffers.ToList();

        // Returns a weekly offer by its unique ID
        public WeeklyOffer? Get(int id) => _context.WeeklyOffers.Find(id);

        // Returns the current weekly offer based on today's date
        public WeeklyOffer? GetCurrentOffer()
        {
            var today = DateTime.Today;
            // Finds the first offer where today's date is within the valid period
            return _context.WeeklyOffers.FirstOrDefault(o => o.ValidFrom <= today && o.ValidTo >= today);
        }

        // Adds a new weekly offer to the database and saves changes
        public WeeklyOffer Add(WeeklyOffer offer)
        {
            _context.WeeklyOffers.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        // Updates an existing weekly offer and saves changes
        public WeeklyOffer Update(WeeklyOffer offer)
        {
            _context.WeeklyOffers.Update(offer);
            _context.SaveChanges();
            return offer;
        }

        // Deletes a weekly offer by ID if found, then saves changes
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