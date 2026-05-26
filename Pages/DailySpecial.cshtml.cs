using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class DailySpecialModel : PageModel
    {
        private readonly DailySpecialService _specialService;
        private readonly MenuService _menuService;
        public DailySpecial? TodaysSpecial { get; set; }
        public List<MenuItem> AllMenuItems { get; set; } = new();
        [BindProperty] public int SelectedMenuItemId { get; set; }

        public DailySpecialModel(DailySpecialService specialService, MenuService menuService)
        {
            _specialService = specialService;
            _menuService = menuService;
        }

        public void OnGet() { TodaysSpecial = _specialService.GetTodaysSpecial(); AllMenuItems = _menuService.GetAll(); }
        public IActionResult OnPost() { if (SelectedMenuItemId > 0) _specialService.SetDailySpecial(SelectedMenuItemId, DateTime.Today); return RedirectToPage(); }
    }
}