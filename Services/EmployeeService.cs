using KantineApp.Models;
using KantineApp.Repository;

namespace KantineApp.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<Employee> GetAll() => _employeeRepo.GetAll();
        public Employee? Get(int id) => _employeeRepo.Get(id);
        public Employee? GetByEmployeeNumber(int employeeNumber) => _employeeRepo.GetByEmployeeNumber(employeeNumber);
        public void Add(Employee employee) => _employeeRepo.Add(employee);
        public void Update(Employee employee) => _employeeRepo.Update(employee);
        public void Delete(int id) => _employeeRepo.Delete(id);
    }
}