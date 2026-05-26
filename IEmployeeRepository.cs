using KantineApp.Models;

namespace KantineApp.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee? Get(int id);
        Employee? GetByEmployeeNumber(int employeeNumber);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee? Delete(int id);
    }
}