namespace KantineApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickupTime { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new();
    }
}
