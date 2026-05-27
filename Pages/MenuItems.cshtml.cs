using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for managing menu items in the Razor Page
    public class MenuItemsModel : PageModel
    {
        private readonly MenuService _menuService;

        // List of all menu items to display on the page
        public List<MenuItem> MenuItems { get; set; } = new();

        // Bound property for creating a new menu item via the form
        [BindProperty] public MenuItem NewMenuItem { get; set; } = new();

        // Constructor: injects the MenuService
        public MenuItemsModel(MenuService menuService) => _menuService = menuService;

        // Handles GET requests: loads all menu items
        public void OnGet() => MenuItems = _menuService.GetAll();

        // Handles POST requests for adding a new menu item
        public IActionResult OnPost()
        {
            // If the model state is invalid, reload menu items and return to the page
            if (!ModelState.IsValid)
            {
                MenuItems = _menuService.GetAll();
                return Page();
            }
            // Add the new menu item and redirect to refresh the page
            _menuService.Add(NewMenuItem);
            return RedirectToPage();
        }

        // Handles POST requests for deleting a menu item by ID
        public IActionResult OnPostDelete(int id)
        {
            _menuService.Delete(id);
            return RedirectToPage();
        }
    }
}