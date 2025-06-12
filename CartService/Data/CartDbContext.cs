using CartService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CartService.Data
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> opts) : base(opts) { }

        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
    }
}
