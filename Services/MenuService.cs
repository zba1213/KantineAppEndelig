using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    // Service for handling business logic related to MenuItemss
    public class MenuService
    {
        private readonly IMenuRepository _menuRepo;

        // Constructor: injects the menu repository
        public MenuService(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        // Returns all menu items
        public List<MenuItem> GetAll() => _menuRepo.GetAllMenuItems();

        // Returns a menu item by its unique ID
        public MenuItem? Get(int id) => _menuRepo.GetMenuItem(id);

        // Adds a new menu item
        public void Add(MenuItem item) => _menuRepo.AddMenuItem(item);

        // Updates an existing menu item
        public void Update(MenuItem item) => _menuRepo.UpdateMenuItem(item);

        // Deletes a menu item by ID
        public void Delete(int id) => _menuRepo.DeleteMenuItem(id);
    }
}