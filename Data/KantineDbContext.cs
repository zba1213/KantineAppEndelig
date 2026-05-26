using KantineApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KantineApp.Data
{
    public class KantineDbContext : DbContext
    {
        public KantineDbContext(DbContextOptions<KantineDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<DailySpecial> DailySpecials { get; set; }
        public DbSet<WeeklyOffer> WeeklyOffers { get; set; }
    }
}