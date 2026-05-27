using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    // Service for handling business logic related to Employees
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        // Constructor: injects the employee repository
        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // Returns all employees
        public List<Employee> GetAll() => _employeeRepo.GetAll();

        // Returns an employee by their unique ID
        public Employee? Get(int id) => _employeeRepo.Get(id);

        // Returns an employee by their unique employee number
        public Employee? GetByEmployeeNumber(int employeeNumber) => _employeeRepo.GetByEmployeeNumber(employeeNumber);

        // Adds a new employee
        public void Add(Employee employee) => _employeeRepo.Add(employee);

        // Updates an existing employee
        public void Update(Employee employee) => _employeeRepo.Update(employee);

        // Deletes an employee by ID
        public void Delete(int id) => _employeeRepo.Delete(id);
    }
}