using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Migrations;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class OrderAPIController : ControllerBase
          {
                    private readonly Ecommerecewebstedatabase _context;
                    private readonly IHttpClientFactory _httpClientFactory;
                    private readonly string _googleApiKey = "YOUR_GOOGLE_MAPS_API_KEY";
                    public readonly IOrderRepository _iorderRepository;
                    public OrderAPIController(Ecommerecewebstedatabase context, IHttpClientFactory httpClientFactory, IOrderRepository iorderrespository)
                    {
                              this._context = context;
                              this._httpClientFactory = httpClientFactory;
                              this._iorderRepository = iorderrespository;
                    }
             

                    [HttpPost("place-order")]
                    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderDto dto)
                    {
                              // 1. Address validate karein
                              var address = await _context.deliverypartnermodels.FindAsync(dto.AddressId);
                              if (address == null) return NotFound("Address not found");

                              // 2. Store coordinates aur Google Maps API call
                              decimal storeLat = 28.5355m;
                              decimal storeLng = 77.3910m;

                              var client = _httpClientFactory.CreateClient();
                              string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={storeLat},{storeLng}&destination={address.Latitude},{address.Longitude}&key={_googleApiKey}";

                              var response = await client.GetFromJsonAsync<GoogleDirectionsResponse>(url);

                              decimal distanceKms = 0;
                              string durationText = "15 mins";

                              if (response?.routes != null && response.routes.Count > 0)
                              {
                                        var leg = response.routes[0].legs[0];
                                        distanceKms = (decimal)(leg.distance.value / 1000.0);
                                        durationText = leg.duration.text;
                              }

                              // 3. Order object create karein (explicit casting ke sath taaki type mismatch error na aaye)
                              var order = new Order
                              {
                                        UserId = int.Parse(dto.UserId),
                                        OrderNumber = "#" + new Random().Next(100000, 999999),
                                        AddressId = dto.AddressId,
                                        StoreId = 1,
                                        Ordertotal = dto.TotalAmount,
                                        OrderStatus = "Dispatched",
                                        DistanceInKm = (double)distanceKms, // Agar model me double hai toh cast kiya gaya hai
                                        EstimatedTime = durationText,
                                        CreatedAt = DateTime.UtcNow,
                                        PaymentMode = string.IsNullOrEmpty(dto.PaymentMode) ? "COD" : dto.PaymentMode,

                                        // Order Items mapping (ensure karein ki DTO me Items list maujood ho)
                                        OrderItemss = dto.Items?.Select(i => new OrderItem
                                        {
                                                  MedicineId = i.MedicineId,
                                                  UnitPrice = i.UnitPrice,
                                                  Discount = i.Discount,
                                                  Quantity = i.Quantity,
                                                  Totalprice = (i.UnitPrice - i.Discount) * i.Quantity
                                        }).ToList()
                              };

                              // 4. Database me save karein
                              _context.orderss.Add(order);
                              await _context.SaveChangesAsync();

                              // 5. Success response return karein
                              return Ok(new
                              {
                                        success = true,
                                        message = "Order placed successfully",
                                        orderId = order.Id,
                                        orderNumber = order.OrderNumber,
                                        distance = distanceKms,
                                        eta = durationText
                              });
                    }




                    // --- API Controllers ---

                    [HttpGet("AllOrder")]
                    public ActionResult<IEnumerable<object>> GetAllOrders()
                    {
                              try
                              {
                                        var listorder = _iorderRepository.ListOrder();
                                        if (listorder == null || !listorder.Any())
                                        {
                                                  return NotFound(new { message = "No orders found." });
                                        }

                                        var result = listorder.Select(o => new {
                                                  Id = o.Id,
                                                  UserId = o.UserId,
                                                  OrderNumber = o.OrderNumber,
                                                  OrderStatus = o.OrderStatus,
                                                  OrderTotal = o.Ordertotal,
                                                  PaymentMode = o.PaymentMode,
                                                  AddressId = o.AddressId,
                                                  StoreId = o.StoreId,
                                                  CreatedAt = o.CreatedAt,
                                                  OrderItemss = o.OrderItemss?.Select(i => new {
                                                            Id = i.Id,
                                                            OrderId = i.OrderId,
                                                            MedicineId = i.MedicineId,
                                                            Quantity = i.Quantity,
                                                            UnitPrice = i.UnitPrice,
                                                            Discount = i.Discount,
                                                            TotalPrice = i.Totalprice
                                                  })
                                        });

                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { message = ex.Message });
                              }
                    }

                    [HttpGet("AllOrderItem")]
                    public ActionResult<IEnumerable<object>> GetAllOrderItems()
                    {
                              try
                              {
                                        var listorderitem = _iorderRepository.Listorderitem();
                                        if (listorderitem == null || !listorderitem.Any())
                                        {
                                                  return NotFound(new { message = "No order items found." });
                                        }

                                        var result = listorderitem.Select(i => new {
                                                  Id = i.Id,
                                                  OrderId = i.OrderId,
                                                  MedicineId = i.MedicineId,
                                                  OrderNumber = i.Order != null ? i.Order.OrderNumber : string.Empty,
                                                  Quantity = i.Quantity,
                                                  UnitPrice = i.UnitPrice,
                                                  Discount = i.Discount,
                                                  TotalPrice = i.Totalprice
                                        });

                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { message = ex.Message });
                              }
                    }

                    //[HttpGet("AllOrderItem")]
                    //public ActionResult<IEnumerable<object>> GetAllOrderItems()
                    //{
                    //          try
                    //          {
                    //                    var listorderitem = _iorderRepository.Listorderitem();
                    //                    if (listorderitem == null || !listorderitem.Any())
                    //                    {
                    //                              return NotFound(new { message = "No order items found." });
                    //                    }

                    //                    var result = listorderitem.Select(i => new {
                    //                              Id = i.Id,
                    //                              OrderId = i.OrderId,
                    //                              MedicineId = i.MedicineId,
                    //                              OrderNumber = i.Order?.OrderNumber ?? string.Empty, // Null safety ke liye
                    //                              Quantity = i.Quantity,
                    //                              UnitPrice = i.UnitPrice,
                    //                              Discount = i.Discount,
                    //                              TotalPrice = i.Totalprice
                    //                    });

                    //                    return Ok(result);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new { message = ex.Message });
                    //          }
                    //}


                    [HttpPost("CreateOrder")]
                    public async Task<IActionResult> CreateOrder([FromBody] Order order)
                    {
                              // 1. Clear navigation property validation errors
                              foreach (var key in ModelState.Keys.Where(k => k.EndsWith(".Order") || k == "User" || k == "Address").ToList())
                              {
                                        ModelState.Remove(key);
                              }

                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(ModelState);
                              }

                              if (order == null)
                              {
                                        return BadRequest(new { success = false, message = "Order payload cannot be null." });
                              }

                              if (_context == null || _context.orderss == null)
                              {
                                        return StatusCode(500, new { success = false, message = "Database context is not initialized." });
                              }

                              try
                              {
                                        if (order.OrderItemss == null || !order.OrderItemss.Any())
                                        {
                                                  return BadRequest(new { success = false, message = "Order items list cannot be empty." });
                                        }

                                        // Optional: Check if user exists in database to prevent FK violation crash
                                        bool userExists = _context.userMediciness != null && await _context.userMediciness.AnyAsync(u => u.id == order.UserId);
                                        if (!userExists)
                                        {
                                                  return BadRequest(new { success = false, message = $"User with ID {order.UserId} does not exist in the database." });
                                        }

                                        // Generate unique order details safely
                                        order.OrderNumber = "#" + new Random().Next(100000, 999999);
                                        order.OrderStatus = "Pending";
                                        order.PaymentMode = string.IsNullOrEmpty(order.PaymentMode) ? "COD" : order.PaymentMode;
                                        order.CreatedAt = DateTime.UtcNow;

                                        // Null-safe iteration over order items
                                        foreach (var item in order.OrderItemss)
                                        {
                                                  if (item != null)
                                                  {
                                                            item.Order = null; // Prevent circular reference tracking issues
                                                            if (item.Totalprice == 0)
                                                            {
                                                                      item.Totalprice = item.UnitPrice * item.Quantity;
                                                            }
                                                  }
                                        }

                                        _context.orderss.Add(order);
                                        await _context.SaveChangesAsync();

                                        return Ok(new
                                        {
                                                  success = true,
                                                  message = "Order created successfully",
                                                  orderId = order.Id,
                                                  orderNumber = order.OrderNumber
                                        });
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { success = false, message = ex.InnerException?.Message ?? ex.Message });
                              }
                    }

                    // GET: api/OrderAPI/AllOrder?search=query
                    [HttpGet("SearchOrders")]
                    public async Task<IActionResult> SearchOrders([FromQuery] string search)
                    {
                              var orders = await _iorderRepository.GetAllOrSearchOrdersAsync(search);
                              return Ok(orders);
                    }

                    // GET: api/OrderAPI/Details/5
                    [HttpGet("Details/{id}")]
                    public async Task<IActionResult> GetOrderDetails(int id)
                    {
                              var order = await _iorderRepository.GetOrderDetailsByIdAsync(id);
                              if (order == null) return NotFound(new { message = "Order not found" });
                              return Ok(order);
                    }

                    // PUT: api/OrderAPI/Update/5
                    [HttpPut("Update/{id}")]
                    public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order updatedOrder)
                    {
                              var success = await _iorderRepository.UpdateOrderAsync(id, updatedOrder);
                              if (!success) return NotFound(new { message = "Order not found for update" });
                              return Ok(new { message = "Order updated successfully" });
                    }

                    // DELETE: api/OrderAPI/Delete/5
                    [HttpDelete("Delete/{id}")]
                    public async Task<IActionResult> DeleteOrder(int id)
                    {
                              var success = await _iorderRepository.DeleteOrderAsync(id);
                              if (!success) return NotFound(new { message = "Order not found for deletion" });
                              return Ok(new { message = "Order deleted successfully" });
                    }
          }
}

