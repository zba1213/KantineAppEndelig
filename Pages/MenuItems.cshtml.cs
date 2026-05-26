using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class MenuItemsModel : PageModel
    {
        private readonly MenuService _menuService;
        public List<MenuItem> MenuItems { get; set; } = new();
        [BindProperty] public MenuItem NewMenuItem { get; set; } = new();
        public MenuItemsModel(MenuService menuService) => _menuService = menuService;
        public void OnGet() => MenuItems = _menuService.GetAll();
        public IActionResult OnPost() { if (!ModelState.IsValid) { MenuItems = _menuService.GetAll(); return Page(); } _menuService.Add(NewMenuItem); return RedirectToPage(); }
        public IActionResult OnPostDelete(int id) { _menuService.Delete(id); return RedirectToPage(); }
    }
}