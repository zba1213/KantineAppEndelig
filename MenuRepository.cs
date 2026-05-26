using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly KantineDbContext _context;

        public MenuRepository(KantineDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAllMenuItems() => _context.MenuItems.ToList();
        public MenuItem? GetMenuItem(int id) => _context.MenuItems.Find(id);

        public void AddMenuItem(MenuItem item)
        {
            _context.MenuItems.Add(item);
            _context.SaveChanges();
        }

        public void UpdateMenuItem(MenuItem item)
        {
            _context.MenuItems.Update(item);
            _context.SaveChanges();
        }

        public void DeleteMenuItem(int id)
        {
            var item = _context.MenuItems.Find(id);
            if (item != null)
            {
                _context.MenuItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}