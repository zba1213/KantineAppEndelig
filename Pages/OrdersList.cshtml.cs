using Microsoft.AspNetCore.Mvc.RazorPages;
using KantineApp.Models;
using KantineApp.Services;

namespace KantineApp.Pages
{
    public class OrdersListModel : PageModel
    {
        private readonly OrderService _orderService;
        public List<Order> Orders { get; set; } = new();
        public OrdersListModel(OrderService orderService) => _orderService = orderService;
        public void OnGet() => Orders = _orderService.GetAll();
    }
}