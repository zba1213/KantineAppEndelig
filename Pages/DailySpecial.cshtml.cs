using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for handling the Daily Special Razor Page
    public class DailySpecialModel : PageModel
    {
        private readonly DailySpecialService _specialService;
        private readonly MenuService _menuService;

        // Holds today's special, if any
        public DailySpecial? TodaysSpecial { get; set; }

        // List of all menu items for selection in the UI
        public List<MenuItem> AllMenuItems { get; set; } = new();

        // Bound property for the selected menu item ID from the form
        [BindProperty] public int SelectedMenuItemId { get; set; }

        // Constructor: injects the required services
        public DailySpecialModel(DailySpecialService specialService, MenuService menuService)
        {
            _specialService = specialService;
            _menuService = menuService;
        }

        // Handles GET requests: loads today's special and all menu items
        public void OnGet()
        {
            TodaysSpecial = _specialService.GetTodaysSpecial();
            AllMenuItems = _menuService.GetAll();
        }

        // Handles POST requests: sets today's special if a menu item is selected, then redirects
        public IActionResult OnPost()
        {
            if (SelectedMenuItemId > 0)
                _specialService.SetDailySpecial(SelectedMenuItemId, DateTime.Today);
            return RedirectToPage();
        }
    }
}