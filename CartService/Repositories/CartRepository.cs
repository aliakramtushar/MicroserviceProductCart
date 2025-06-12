using CartService.Data;
using CartService.Models;
using Microsoft.EntityFrameworkCore;

namespace CartService.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _db;
        public CartRepository(CartDbContext db) => _db = db;

        public async Task<Cart?> GetCartForUserAsync(string userId)
        {
            return await _db.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddOrUpdateItems(string userId, List<CartItem> items)
        {
            var cart = await GetCartForUserAsync(userId) ?? new Cart { UserId = userId };
            foreach (var item in items)
            {
                var existing = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existing != null)
                    existing.Quantity = item.Quantity;
                else
                    cart.Items.Add(item);
            }

            if (cart.Id == null || cart.Id == Guid.Empty || cart.Id == Guid.NewGuid())
            {
                _db.Carts.Add(cart);
            }
            await _db.SaveChangesAsync();
        }

        public async Task ClearCart(string userId)
        {
            var cart = await GetCartForUserAsync(userId);
            if (cart != null) { _db.CartItems.RemoveRange(cart.Items); await _db.SaveChangesAsync(); }
        }
    }
}