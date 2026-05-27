using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    // Service for handling business logic related to DailySpecials
    public class DailySpecialService
    {
        private readonly IDailySpecialRepository _specialRepo;
        private readonly IMenuRepository _menuRepo;

        // Constructor: injects the required repositories
        public DailySpecialService(IDailySpecialRepository specialRepo, IMenuRepository menuRepo)
        {
            _specialRepo = specialRepo;
            _menuRepo = menuRepo;
        }

        // Returns all daily specials
        public List<DailySpecial> GetAll() => _specialRepo.GetAll();

        // Returns a daily special by its unique ID
        public DailySpecial? Get(int id) => _specialRepo.Get(id);

        // Returns today's daily special, if any
        public DailySpecial? GetTodaysSpecial() => _specialRepo.GetByDate(DateTime.Today);

        // Sets a daily special for a given menu item and date
        public void SetDailySpecial(int menuItemId, DateTime date)
        {
            // Retrieve the menu item by ID
            var menuItem = _menuRepo.GetMenuItem(menuItemId);
            if (menuItem == null) throw new Exception("Ret ikke fundet"); // "Dish not found"

            // Create and add the new daily special
            var special = new DailySpecial { Date = date, MenuItemId = menuItemId };
            _specialRepo.Add(special);
        }

        // Deletes a daily special by ID
        public void Delete(int id) => _specialRepo.Delete(id);
    }
}