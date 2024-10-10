using Microsoft.EntityFrameworkCore;
using POSWebApi.Models;

namespace POSWebApi.Data
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null;
        public DbSet<Order> Oders { get; set; } = null;
        public DbSet<Customer> Customers { get; set; } = null;
    }
}