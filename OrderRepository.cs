using KantineApp.Data;
using KantineApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KantineApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KantineDbContext _context;

        public OrderRepository(KantineDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.Employee)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.MenuItem)
                .ToList();
        }

        public Order? Get(int id)
        {
            return _context.Orders
                .Include(o => o.Employee)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.MenuItem)
                .FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrdersByEmployee(int employeeId)
        {
            return _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.MenuItem)
                .ToList();
        }

        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }

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