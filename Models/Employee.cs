using System.ComponentModel.DataAnnotations;

namespace KantineApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeNumber { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();
    }    
}
