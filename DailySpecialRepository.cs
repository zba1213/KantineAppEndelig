using KantineApp.Data;
using KantineApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KantineApp.Repository
{
    public class DailySpecialRepository : IDailySpecialRepository
    {
        private readonly KantineDbContext _context;

        public DailySpecialRepository(KantineDbContext context)
        {
            _context = context;
        }

        public List<DailySpecial> GetAll()
        {
            return _context.DailySpecials.Include(d => d.MenuItem).ToList();
        }

        public DailySpecial? Get(int id)
        {
            return _context.DailySpecials.Include(d => d.MenuItem).FirstOrDefault(d => d.Id == id);
        }

        public DailySpecial? GetByDate(DateTime date)
        {
            return _context.DailySpecials.Include(d => d.MenuItem).FirstOrDefault(d => d.Date.Date == date.Date);
        }

        public DailySpecial Add(DailySpecial dailySpecial)
        {
            _context.DailySpecials.Add(dailySpecial);
            _context.SaveChanges();
            return dailySpecial;
        }

        public DailySpecial Update(DailySpecial dailySpecial)
        {
            _context.DailySpecials.Update(dailySpecial);
            _context.SaveChanges();
            return dailySpecial;
        }

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