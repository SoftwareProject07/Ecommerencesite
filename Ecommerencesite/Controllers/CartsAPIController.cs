using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class CartsAPIController : ControllerBase
          {
                    public readonly ICartRepository _cartRepository;
                    public CartsAPIController(ICartRepository cartRepository)
                    {
                          this._cartRepository = cartRepository;
                    }
                    [HttpPost("addcart")]
                    public async Task<IActionResult> AddToCart(int userId, int medicineId, int quantity)
                    {
                              await _cartRepository.AddToCart(userId, medicineId, quantity);
                              return Ok("Item added to cart");
                    }

          }
}
