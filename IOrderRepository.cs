using KantineApp.Models;

namespace KantineApp.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order? Get(int id);
        Order Add(Order order);
        Order Update(Order order);
        Order? Delete(int id);
        List<Order> GetOrdersByEmployee(int employeeId);
    }
}