using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KantineDbContext _context;

        public EmployeeRepository(KantineDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll() => _context.Employees.ToList();
        public Employee? Get(int id) => _context.Employees.Find(id);
        public Employee? GetByEmployeeNumber(int employeeNumber) => _context.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);

        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee? Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }
    }
}