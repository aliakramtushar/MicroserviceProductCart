using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServiceImpl _productService;
        public ProductsController(ProductServiceImpl svc) => _productService = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _productService.Get(id);
            return p is not null ? Ok(p) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            await _productService.Add(p);
            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Product p)
        {
            if (id != p.Id) return BadRequest();
            var existing = await _productService.Get(id);
            if (existing == null) return NotFound();
            await _productService.Update(p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
    }
}
