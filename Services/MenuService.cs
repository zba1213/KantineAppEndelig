using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepo;

        public MenuService(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public List<MenuItem> GetAll() => _menuRepo.GetAllMenuItems();
        public MenuItem? Get(int id) => _menuRepo.GetMenuItem(id);
        public void Add(MenuItem item) => _menuRepo.AddMenuItem(item);
        public void Update(MenuItem item) => _menuRepo.UpdateMenuItem(item);
        public void Delete(int id) => _menuRepo.DeleteMenuItem(id);
    }
}