using CQRS_Demo.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CQRS_Demo.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OrdersDb");
        }
    }
}
