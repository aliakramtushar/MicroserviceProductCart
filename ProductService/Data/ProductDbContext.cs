using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opts) : base(opts) { }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 4);  // Set precision and scale as needed
        }
    }
}
