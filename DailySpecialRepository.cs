using KantineApp.Data;
using KantineApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KantineApp.Repository
{
    // Repository for managing DailySpecial entities in the database
    public class DailySpecialRepository : IDailySpecialRepository
    {
        private readonly KantineDbContext _context;

        // Constructor: injects the database context
        public DailySpecialRepository(KantineDbContext context)
        {
            _context = context;
        }

        // Returns all DailySpecials, including related MenuItem data
        public List<DailySpecial> GetAll()
        {
            return _context.DailySpecials.Include(d => d.MenuItem).ToList();
        }

        // Returns a DailySpecial by its ID, including related MenuItem data
        public DailySpecial? Get(int id)
        {
            return _context.DailySpecials.Include(d => d.MenuItem).FirstOrDefault(d => d.Id == id);
        }

        // Returns a DailySpecial for a specific date, including related MenuItem data
        public DailySpecial? GetByDate(DateTime date)
        {
            // Compare only the date part (ignoring time)
            return _context.DailySpecials.Include(d => d.MenuItem).FirstOrDefault(d => d.Date.Date == date.Date);
        }

        // Adds a new DailySpecial to the database and saves changes
        public DailySpecial Add(DailySpecial dailySpecial)
        {
            _context.DailySpecials.Add(dailySpecial);
            _context.SaveChanges();
            return dailySpecial;
        }

        // Updates an existing DailySpecial and saves changes
        public DailySpecial Update(DailySpecial dailySpecial)
        {
            _context.DailySpecials.Update(dailySpecial);
            _context.SaveChanges();
            return dailySpecial;
        }

        // Deletes a DailySpecial by ID if it exists, then saves changes
        public DailySpecial? Delete(int id)
        {
            var special = _context.DailySpecials.Find(id);
            if (special != null)
            {
                _context.DailySpecials.Remove(special);
                _context.SaveChanges();
            }
            return special;
        }
    }
}