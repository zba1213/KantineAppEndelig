using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    // Repository for managing MenuItem entities in the database
    public class MenuRepository : IMenuRepository
    {
        private readonly KantineDbContext _context;

        // Constructor: injects the database context
        public MenuRepository(KantineDbContext context)
        {
            _context = context;
        }

        // Returns all menu items from the database
        public List<MenuItem> GetAllMenuItems() => _context.MenuItems.ToList();

        // Returns a menu item by its unique ID
        public MenuItem? GetMenuItem(int id) => _context.MenuItems.Find(id);

        // Adds a new menu item to the database and saves changes
        public void AddMenuItem(MenuItem item)
        {
            _context.MenuItems.Add(item);
            _context.SaveChanges();
        }

        // Updates an existing menu item and saves changes
        public void UpdateMenuItem(MenuItem item)
        {
            _context.MenuItems.Update(item);
            _context.SaveChanges();
        }

        // Deletes a menu item by ID if found, then saves changes
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