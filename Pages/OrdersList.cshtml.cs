using Microsoft.AspNetCore.Mvc.RazorPages;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    // PageModel for displaying a list of all orders in the Razor Page
    public class OrdersListModel : PageModel
    {
        private readonly OrderService _orderService;

        // List of all orders to display on the page
        public List<Order> Orders { get; set; } = new();

        // Constructor: injects the OrderService
        public OrdersListModel(OrderService orderService) => _orderService = orderService;

        // Handles GET requests: loads all orders for display
        public void OnGet() => Orders = _orderService.GetAll();
    }
}