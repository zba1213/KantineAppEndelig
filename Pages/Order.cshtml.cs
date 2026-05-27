using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for handling order creation in the Razor Page
    public class OrderModel : PageModel
    {
        private readonly MenuService _menuService;
        private readonly OrderService _orderService;

        // List of all menu items to display for selection
        public List<MenuItem> MenuItems { get; set; } = new();

        // Bound property for the employee number input
        [BindProperty] public int EmployeeNumber { get; set; }

        // Bound property for the selected menu item IDs from the form
        [BindProperty] public List<int> SelectedItemIds { get; set; } = new();

        // Bound property for the quantities corresponding to the selected menu items
        [BindProperty] public List<int> Quantities { get; set; } = new();

        // Constructor: injects the required services
        public OrderModel(MenuService menuService, OrderService orderService)
        {
            _menuService = menuService;
            _orderService = orderService;
        }

        // Handles GET requests: loads all menu items for display
        public void OnGet() => MenuItems = _menuService.GetAll();

        // Handles POST requests: processes the order form submission
        public IActionResult OnPost()
        {
            // If the model state is invalid, reload menu items and return to the page
            if (!ModelState.IsValid)
            {
                MenuItems = _menuService.GetAll();
                return Page();
            }

            // Build a list of (menuItemId, quantity) tuples from the selected items and quantities
            var items = new List<(int, int)>();
            for (int i = 0; i < SelectedItemIds.Count; i++)
                if (SelectedItemIds[i] != 0 && i < Quantities.Count)
                    items.Add((SelectedItemIds[i], Quantities[i] > 0 ? Quantities[i] : 1));

            try
            {
                // Attempt to create the order using the service
                _orderService.CreateOrder(EmployeeNumber, items);
                TempData["SuccessMessage"] = "Bestilling gennemført!";
                return RedirectToPage("/OrderConfirmation");
            }
            catch (Exception ex)
            {
                // If an error occurs (e.g., employee not found), add error to model state and reload menu items
                ModelState.AddModelError("", ex.Message);
                MenuItems = _menuService.GetAll();
                return Page();
            }
        }
    }
}