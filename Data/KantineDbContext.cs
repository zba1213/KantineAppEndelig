using KantineApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KantineApp.Data
{
    // The Entity Framework Core database context for the KantineApp.
    // This context manages all the main entities and their relationships.
    public class KantineDbContext : DbContext
    {
        // Constructor: passes options to the base DbContext
        public KantineDbContext(DbContextOptions<KantineDbContext> options) : base(options) { }

        
        public DbSet<Employee> Employees { get; set; }

        
        public DbSet<MenuItem> MenuItems { get; set; }

        
        public DbSet<Order> Orders { get; set; }

        
        public DbSet<OrderLine> OrderLines { get; set; }

        
        public DbSet<DailySpecial> DailySpecials { get; set; }

        
        public DbSet<WeeklyOffer> WeeklyOffers { get; set; }
    }
}