using CartService.Models;
using CartService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartServiceImpl _svc;
        public CartController(CartServiceImpl svc) => _svc = svc;

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            var (cart, products) = await _svc.GetCartWithDetails(userId);
            if (cart == null) return NotFound();

            return Ok(new { cart, products });
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddOrUpdate(string userId, List<CartItem> items)
        {
            await _svc.AddOrUpdate(userId, items);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Clear(string userId)
        {
            await _svc.Clear(userId);
            return NoContent();
        }
    }
}
