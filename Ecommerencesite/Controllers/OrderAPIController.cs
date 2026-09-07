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
                              var address = await _context.deliverypartnermodels.FindAsync(dto.AddressId);
                              if (address == null) return NotFound("Address not found");

                              decimal storeLat = 28.5355m;
                              decimal storeLng = 77.3910m;

                              var client = _httpClientFactory.CreateClient();
                              string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={storeLat},{storeLng}&destination={address.Latitude},{address.Longitude}&key={_googleApiKey}";

                              var response = await client.GetFromJsonAsync<GoogleDirectionsResponse>(url);

                              decimal distanceKm = 0;
                              string durationText = "15 mins";

                              if (response?.routes != null && response.routes.Count > 0)
                              {
                                        var leg = response.routes[0].legs[0];
                                        distanceKm = (decimal)(leg.distance.value / 1000.0);
                                        durationText = leg.duration.text;
                              }

                              var order = new Order
                              {
                                        UserId = int.Parse(dto.UserId),
                                        OrderNumber = "#" + new Random().Next(100000, 999999),
                                        AddressId = dto.AddressId,
                                        StoreId = 1,
                                        Ordertotal = dto.TotalAmount,
                                        OrderStatus = "Dispatched",
                                        DistanceInKm = distanceKm,
                                        EstimatedTime = durationText,
                                        CreatedAt = DateTime.UtcNow

                                        //OrderNumber = dto.ordernu,
                                        //OrderStatus = o.OrderStatus,
                                        //Ordertotal = order.or, // Model ke mutabiq 'Ordertotal'
                                        //PaymentMode = o.PaymentMode, // Ab error nahi aayega
                                        //AddressId = o.AddressId,
                                        //StoreId = o.StoreId,
                                        //CreatedAt = o.CreatedAt,
                                        //Address = o.Address,
                              };

                              _context.orderss.Add(order);
                              await _context.SaveChangesAsync();

                              return Ok(new { success = true, message = "Order placed successfully", orderId = order.id, distance = distanceKm, eta = durationText });
                    }
                    //[HttpGet("AllOrderItem")]
                    //public List<OrderItem> Listorderitem()
                    //{
                    //          var listorderitem = _iorderRepository.Listorderitem().ToList();
                    //          return listorderitem;
                    //}
                    //[HttpGet("AllOrder")]
                    //public List<Order> ListOrder()
                    //{
                    //          var listorder = _iorderRepository.ListOrder().ToList();
                    //          return listorder;
                    //}



                    //[HttpGet("AllOrder")]
                    //public ActionResult<IEnumerable<Order>> GetAllOrders()
                    //{
                    //          try
                    //          {
                    //                    var listorder = _iorderRepository.ListOrder();
                    //                    if (listorder == null || !listorder.Any())
                    //                    {
                    //                              return NotFound(new { message = "No orders found." });
                    //                    }
                    //                    return Ok(listorder);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new { message = ex.Message });
                    //          }
                    //}


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
                                                //  Id = o.id,
                                                  OrderNumber = o.OrderNumber,
                                                  OrderStatus = o.OrderStatus,
                                                  OrderTotal = o.Ordertotal, // Model ke mutabiq 'Ordertotal'
                                                  PaymentMode = o.PaymentMode, // Ab error nahi aayega
                                                  AddressId = o.AddressId,
                                                  StoreId = o.StoreId,
                                                  CreatedAt = o.CreatedAt,
                                                  Address = o.Address,
                                                  OrderItemss = o.orderItemss?.Select(i => new {
                                                            Id = i.Id,
                                                            // baki item properties agar hon toh
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
                    public ActionResult<IEnumerable<OrderItem>> GetAllOrderItems()
                    {
                              try
                              {
                                        var listorderitem = _iorderRepository.Listorderitem();
                                        if (listorderitem == null || !listorderitem.Any())
                                        {
                                                  return NotFound(new { message = "No order items found." });
                                        }
                                        return Ok(listorderitem);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { message = ex.Message });
                              }
                    }

                    //[HttpPost("CreateOrder")]
                    //public void CreateOrder(Order order)
                    //{
                    //          _iorderRepository.CreateOrder(order);   
                    //}

                    [HttpPost("CreateOrder")]
                    public async Task<IActionResult> CreateOrder(Order order)
                    {
                              // Agar koi model state validation error ho toh detail return karega
                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(ModelState);
                              }

                              try
                              {
                                        if (order == null || order.orderItemss == null || !order.orderItemss.Any())
                                        {
                                                  return BadRequest(new { message = "Invalid order data or empty items list." });
                                        }

                                        order.User = null;
                                        order.Address = null;
                                       // order.OrderNumber = "ORD-" + new Random().Next(100000, 999999);
                                        order.OrderNumber = "#" + new Random().Next(100000, 999999);

                                        order.OrderStatus = "Pending";
                                        //order.PaymentMode = "";
                                        order.CreatedAt = DateTime.UtcNow;

                                        foreach (var item in order.orderItemss)
                                        {
                                                  item.Order = null; // Clear navigation property reference
                                                  if (item.Totalprice == null || item.Totalprice == 0)
                                                  {
                                                            item.Totalprice = (item.UnitPrice ?? 0) * item.Quantity;
                                                  }
                                        }

                                        _context.orderss.Add(order);
                                        await _context.SaveChangesAsync();

                                        return Ok(new { success = true, message = "Order created successfully", orderId = order.id, orderNumber = order.OrderNumber });
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

