using CartService.DTO;

namespace CartService.Clients
{
    public class ProductClient
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public ProductClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _baseUrl = config["ProductServiceUrl"] ?? throw new ArgumentNullException("ProductServiceUrl is missing in config");
        }

        public Task<List<ProductDto>?> GetProductsAsync()
        {
            return _http.GetFromJsonAsync<List<ProductDto>>($"{_baseUrl}api/Products");
        }
    }
}
