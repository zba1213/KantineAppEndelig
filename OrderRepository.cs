using KantineApp.Data;
using KantineApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KantineApp.Repository
{
    // Repository for managing Order entities in the database
    public class OrderRepository : IOrderRepository
    {
        private readonly KantineDbContext _context;

        // Constructor: injects the database context
        public OrderRepository(KantineDbContext context)
        {
            _context = context;
        }

        // Returns all orders, including related Employee, OrderLines, and MenuItem data
        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.Employee) // Include the employee who placed the order
                .Include(o => o.OrderLines) // Include all order lines
                .ThenInclude(ol => ol.MenuItem) // For each order line, include the related menu item
                .ToList();
        }

        // Returns a specific order by ID, including related Employee, OrderLines, and MenuItem data
        public Order? Get(int id)
        {
            return _context.Orders
                .Include(o => o.Employee)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.MenuItem)
                .FirstOrDefault(o => o.Id == id);
        }

        // Returns all orders for a specific employee, including OrderLines and MenuItem data
        public List<Order> GetOrdersByEmployee(int employeeId)
        {
            return _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.MenuItem)
                .ToList();
        }

        // Adds a new order to the database and saves changes
        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        // Updates an existing order and saves changes
        public Order Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }

        // Deletes an order by ID if found, then saves changes
        public Order? Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return order;
        }
    }
}