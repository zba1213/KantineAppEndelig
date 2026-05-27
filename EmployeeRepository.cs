using KantineApp.Data;
using KantineApp.Models;

namespace KantineApp.Repository
{
    // Repository for managing Employee entities in the database
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KantineDbContext _context;

        // Constructor: injects the database context
        public EmployeeRepository(KantineDbContext context)
        {
            _context = context;
        }

        // Returns all employees from the database
        public List<Employee> GetAll() => _context.Employees.ToList();

        // Returns an employee by their unique ID
        public Employee? Get(int id) => _context.Employees.Find(id);

        // Returns an employee by their unique employee number
        public Employee? GetByEmployeeNumber(int employeeNumber) =>
            _context.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);

        // Adds a new employee to the database and saves changes
        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        // Updates an existing employee and saves changes
        public Employee Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        // Deletes an employee by ID if found, then saves changes
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