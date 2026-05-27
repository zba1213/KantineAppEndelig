using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    // Service for handling business logic related to Orders
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMenuRepository _menuRepo;
        private readonly IEmployeeRepository _employeeRepo;

        // Constructor: injects the required repositories
        public OrderService(IOrderRepository orderRepo, IMenuRepository menuRepo, IEmployeeRepository employeeRepo)
        {
            _orderRepo = orderRepo;
            _menuRepo = menuRepo;
            _employeeRepo = employeeRepo;
        }

        // Returns all orders
        public List<Order> GetAll() => _orderRepo.GetAll();

        // Returns an order by its unique ID
        public Order? Get(int id) => _orderRepo.Get(id);

        // Creates a new order for an employee with a list of menu items and their quantities
        public void CreateOrder(int employeeNumber, List<(int menuItemId, int quantity)> items)
        {
            // Find the employee by employee number
            var employee = _employeeRepo.GetByEmployeeNumber(employeeNumber);
            if (employee == null) throw new Exception("Medarbejder ikke fundet"); // "Employee not found"

            // Create a new order and set basic properties
            var order = new Order
            {
                EmployeeId = employee.Id,
                OrderTime = DateTime.Now,
                PickupTime = DateTime.Now.AddHours(1),
                OrderLines = new List<OrderLine>()
            };

            decimal total = 0;
            // For each menu item and quantity, add an order line
            foreach (var (menuItemId, qty) in items)
            {
                var menuItem = _menuRepo.GetMenuItem(menuItemId);
                if (menuItem == null) continue; // Skip if menu item not found

                decimal linePrice = menuItem.Price * qty;
                // Apply 10% discount if the item is not a drink
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

        // Calculates the total consumption for an employee in a given month and year
        public decimal GetMonthlyConsumption(int employeeNumber, int year, int month)
        {
            var employee = _employeeRepo.GetByEmployeeNumber(employeeNumber);
            if (employee == null) return 0;

            var orders = _orderRepo.GetOrdersByEmployee(employee.Id);
            // Sum the total amount for orders in the specified month and year
            return orders.Where(o => o.OrderTime.Year == year && o.OrderTime.Month == month).Sum(o => o.TotalAmount);
        }
    }
}