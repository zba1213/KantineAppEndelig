using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    public class DailySpecialService
    {
        private readonly IDailySpecialRepository _specialRepo;
        private readonly IMenuRepository _menuRepo;

        public DailySpecialService(IDailySpecialRepository specialRepo, IMenuRepository menuRepo)
        {
            _specialRepo = specialRepo;
            _menuRepo = menuRepo;
        }

        public List<DailySpecial> GetAll() => _specialRepo.GetAll();
        public DailySpecial? Get(int id) => _specialRepo.Get(id);
        public DailySpecial? GetTodaysSpecial() => _specialRepo.GetByDate(DateTime.Today);

        public void SetDailySpecial(int menuItemId, DateTime date)
        {
            var menuItem = _menuRepo.GetMenuItem(menuItemId);
            if (menuItem == null) throw new Exception("Ret ikke fundet");

            var special = new DailySpecial { Date = date, MenuItemId = menuItemId };
            _specialRepo.Add(special);
        }

        public void Delete(int id) => _specialRepo.Delete(id);
    }
}