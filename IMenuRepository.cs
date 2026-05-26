using KantineApp.Models;

namespace KantineApp.Repository
{
    public interface IMenuRepository
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem? GetMenuItem(int id);
        void AddMenuItem(MenuItem item);
        void UpdateMenuItem(MenuItem item);
        void DeleteMenuItem(int id);
    }
}