using ProductService.DTO;
using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Services
{
    public class ProductServiceImpl
    {
        private readonly IProductRepository _repo;
        public ProductServiceImpl(IProductRepository repo) => _repo = repo;

        public Task<List<Product>> GetAll() => _repo.GetAllAsync();
        public Task<List<ProductDto>> GetAllProductDto() => _repo.GetAllDtoAsync();
        public Task<Product?> Get(Guid id) => _repo.GetByIdAsync(id);
        public Task Add(Product p) => _repo.AddAsync(p);
        public Task Update(Product p) => _repo.UpdateAsync(p);
        public Task Delete(Guid id) => _repo.DeleteAsync(id);
    }
}
