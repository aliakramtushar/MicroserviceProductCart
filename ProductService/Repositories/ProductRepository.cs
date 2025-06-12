using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTO;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;
        public ProductRepository(ProductDbContext db) => _db = db;

        public async Task<List<Product>> GetAllAsync() => await _db.Products.ToListAsync();
        public async Task<List<ProductDto>> GetAllDtoAsync()
        {
            var products = await _db.Products.ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
        public async Task<Product?> GetByIdAsync(Guid id) => await _db.Products.FindAsync(id);
        public async Task AddAsync(Product p) { _db.Products.Add(p); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(Product p) { _db.Products.Update(p); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(Guid id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p != null) { _db.Products.Remove(p); await _db.SaveChangesAsync(); }
        }
    }
}
