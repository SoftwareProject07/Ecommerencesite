using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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


                    // ➕ ADD TO CART
                    //[Authorize]
                    //[HttpPost("addcart")]
                    //public async Task<IActionResult> AddToCart(int medicineId, int quantity)
                    //{
                    //          // 🔐 Get logged-in user id from token
                    //          var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                    //          if (userIdClaim == null)
                    //                    return Unauthorized("User not logged in");

                    //          int userId = int.Parse(userIdClaim.Value);

                    //          await _cartRepository.AddToCart(userId, medicineId, quantity);

                    //          return Ok("Item added to cart");
                    //}
                    // 🛒 MY CART
                    //Sample demo check 
                    [Authorize]
                    [HttpGet("my-cart")]
                    public async Task<IActionResult> GetMyCart()
                    {
                              // 🔐 Get logged-in user id from JWT
                              var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                              if (userIdClaim == null)
                                        return Unauthorized("User not logged in");

                              int userId = int.Parse(userIdClaim.Value);

                              // 🛒 Fetch only logged-in user's cart
                              var cartItems = await _cartRepository.GetMyCart(userId);

                              return Ok(cartItems);
                    }
          }
}