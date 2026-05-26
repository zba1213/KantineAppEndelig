namespace KantineApp.Models
{
    public class DailySpecial
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
