using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;

using Microsoft.AspNetCore.Mvc;


using System.Linq;

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



                    [HttpPost("AddToCart")]
                    public IActionResult AddToCart([FromBody] Cart cart)
                    {
                              var result = _cartRepository.AddToCart(cart);
                              if (!result.status)
                                        return BadRequest(result);

                              return Ok(result);
                    }



                    [HttpGet("GetCartByUserId/{userId}")]
                    public IActionResult GetCartByUserId(int userId)
                    {
                              try
                              {
                                        if (userId <= 0)
                                                  return BadRequest("Invalid user id");

                                        var result = _cartRepository.GetUserCartItems(userId);

                                        if (result == null)
                                                  return Ok(new List<Cart>());

                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new
                                        {
                                                  Message = "Internal Server Error",
                                                  Error = ex.Message
                                        });
                              }
                    }

                    [HttpGet("AllListCartProduct")]
                    public IActionResult lstCartProduct()
                    {
                              try
                              {
                                        var listcart = _cartRepository.ListUserCartItem();
                                        return Ok(listcart);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new
                                        {
                                                  Message = "Internal Error",
                                                  Error = ex.Message,
                                                  Detail = ex.InnerException?.Message
                                        });
                              }
                    }


                    [HttpGet("badge-count/{userId}")]
                    public IActionResult GetCount(int userId)
                    {
                              var count = _cartRepository.GetCartBadgeCount(userId);
                              return Ok(count); // Response sirf ek number hoga, jaise '1'
                    }



                    //[HttpGet("GetMyCart/{email}")]
                    //public async Task<IActionResult> GetMyCart(string email)
                    //{
                    //          var data = await _cartRepository.GetAddressesCartByEmailAsync(email);
                    //          if (data == null) return NotFound();

                    //          return Ok(data);
                    //}
                    //}


          }
}