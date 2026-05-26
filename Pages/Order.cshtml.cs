using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly MenuService _menuService;
        private readonly OrderService _orderService;
        public List<MenuItem> MenuItems { get; set; } = new();
        [BindProperty] public int EmployeeNumber { get; set; }
        [BindProperty] public List<int> SelectedItemIds { get; set; } = new();
        [BindProperty] public List<int> Quantities { get; set; } = new();

        public OrderModel(MenuService menuService, OrderService orderService)
        {
            _menuService = menuService;
            _orderService = orderService;
        }

        public void OnGet() => MenuItems = _menuService.GetAll();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { MenuItems = _menuService.GetAll(); return Page(); }
            var items = new List<(int, int)>();
            for (int i = 0; i < SelectedItemIds.Count; i++)
                if (SelectedItemIds[i] != 0 && i < Quantities.Count)
                    items.Add((SelectedItemIds[i], Quantities[i] > 0 ? Quantities[i] : 1));
            try { _orderService.CreateOrder(EmployeeNumber, items); TempData["SuccessMessage"] = "Bestilling gennemført!"; return RedirectToPage("/OrderConfirmation"); }
            catch (Exception ex) { ModelState.AddModelError("", ex.Message); MenuItems = _menuService.GetAll(); return Page(); }
        }
    }
}