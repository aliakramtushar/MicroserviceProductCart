using Microsoft.EntityFrameworkCore;

namespace ProductService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
