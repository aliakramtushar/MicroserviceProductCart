using CartService.Clients;
using CartService.DTO;
using CartService.Models;
using CartService.Repositories;

namespace CartService.Services
{
    public class CartServiceImpl
    {
        private readonly ICartRepository _repo;
        private readonly IProductClient _pc;

        public CartServiceImpl(ICartRepository repo, IProductClient pc)
        {
            _repo = repo;
            _pc = pc;
        }

        public async Task<(Cart? cart, List<ProductDto>? products)> GetCartWithDetails(string userId)
        {
            var cart = await _repo.GetCartForUserAsync(userId);
            if (cart == null) return (null, null);

            var prodList = await _pc.GetProductsAsync() ?? new();
            return (cart, prodList);
        }

        public Task AddOrUpdate(string userId, List<CartItem> items)
            => _repo.AddOrUpdateItems(userId, items);

        public Task Clear(string userId)
            => _repo.ClearCart(userId);
    }
}
