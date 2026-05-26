using System.ComponentModel.DataAnnotations;

namespace KantineApp.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, 1000)]
        public decimal Price { get; set; }

        public bool IsDrink { get; set; }
    }
}
