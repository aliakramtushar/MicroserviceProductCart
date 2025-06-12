using CartService.Models;

namespace CartService.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartForUserAsync(string userId);
        Task AddOrUpdateItems(string userId, List<CartItem> items);
        Task ClearCart(string userId);
    }
}
