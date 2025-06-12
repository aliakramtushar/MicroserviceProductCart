using CartService.DTO;

namespace CartService.Clients
{
    public interface IProductClient
    {
        Task<List<ProductDto>?> GetProductsAsync();
    }
}
