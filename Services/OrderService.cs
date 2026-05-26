using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMenuRepository _menuRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public OrderService(IOrderRepository orderRepo, IMenuRepository menuRepo, IEmployeeRepository employeeRepo)
        {
            _orderRepo = orderRepo;
            _menuRepo = menuRepo;
            _employeeRepo = employeeRepo;
        }

        public List<Order> GetAll() => _orderRepo.GetAll();
        public Order? Get(int id) => _orderRepo.Get(id);

        public void CreateOrder(int employeeNumber, List<(int menuItemId, int quantity)> items)
        {
            var employee = _employeeRepo.GetByEmployeeNumber(employeeNumber);
            if (employee == null) throw new Exception("Medarbejder ikke fundet");

            var order = new Order
            {
                EmployeeId = employee.Id,
                OrderTime = DateTime.Now,
                PickupTime = DateTime.Now.AddHours(1),
                OrderLines = new List<OrderLine>()
            };

            decimal total = 0;
            foreach (var (menuItemId, qty) in items)
            {
                var menuItem = _menuRepo.GetMenuItem(menuItemId);
                if (menuItem == null) continue;

                decimal linePrice = menuItem.Price * qty;
                if (!menuItem.IsDrink)
                    linePrice *= 0.9m;

                total += linePrice;
                order.OrderLines.Add(new OrderLine
                {
                    MenuItemId = menuItemId,
                    Quantity = qty,
                    UnitPrice = menuItem.Price
                });
            }
            order.TotalAmount = total;
            _orderRepo.Add(order);
        }

        public decimal GetMonthlyConsumption(int employeeNumber, int year, int month)
        {
            var employee = _employeeRepo.GetByEmployeeNumber(employeeNumber);
            if (employee == null) return 0;

            var orders = _orderRepo.GetOrdersByEmployee(employee.Id);
            return orders.Where(o => o.OrderTime.Year == year && o.OrderTime.Month == month).Sum(o => o.TotalAmount);
        }
    }
}