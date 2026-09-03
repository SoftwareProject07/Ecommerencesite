using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
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
                    public OrderAPIController(Ecommerecewebstedatabase context, IHttpClientFactory httpClientFactory,IOrderRepository iorderrespository)
                    {
                         this.     _context = context;
                         this.     _httpClientFactory = httpClientFactory;
                             this. _iorderRepository = iorderrespository;       
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
                                        OrderNumber = "ORD-" + new Random().Next(100000, 999999),
                                        AddressId = dto.AddressId,
                                        StoreId = 1,
                                        Ordertotal = dto.TotalAmount,
                                        OrderStatus = "Dispatched",
                                        DistanceInKm = distanceKm,
                                        EstimatedTime = durationText,
                                        CreatedAt = DateTime.UtcNow
                              };

                              _context.orderss.Add(order);
                              await _context.SaveChangesAsync();

                              return Ok(new { success = true, message = "Order placed successfully", orderId = order.id, distance = distanceKm, eta = durationText });
                    }
                    [HttpGet("AllOrderItem")]
                    public List<OrderItem> Listorderitem()
                    {
                              var listorderitem = _iorderRepository.Listorderitem().ToList();
                              return listorderitem;
                    }
                    [HttpGet("AllOrder")]
                    public List<Order> ListOrder()
                    {
                              var listorder = _iorderRepository.ListOrder().ToList();
                              return listorder;
                    }

                    [HttpPost("CreateOrder")]
                    public void CreateOrder(Order order)
                    {
                              _iorderRepository.CreateOrder(order);   
                    }


                    // GET: api/orders
                    //[HttpGet("AllOrder")]
                    //public async Task<ActionResult<IEnumerable<Order>>> ListOrder()
                    //{
                    //          var orders = await _context.orderss
                    //              .Include(o => o.orderItemss) // Saare order items load karega
                    //              .Include(o => o.User)       // User details
                    //              .Include(o => o.Address)    // Delivery address details
                    //              .ToListAsync();

                    //          return Ok(orders);
                    //}

                    //// GET: api/orders/items
                    //[HttpGet("AllOrderItem")]
                    //public async Task<ActionResult<IEnumerable<OrderItem>>> Listorderitem()
                    //{
                    //          var orderItems = await _context.orderItemss
                    //              .Include(oi => oi.Order)    // Parent order details
                    //              .ToListAsync();

                    //          return Ok(orderItems);
                    //}


          }
}
