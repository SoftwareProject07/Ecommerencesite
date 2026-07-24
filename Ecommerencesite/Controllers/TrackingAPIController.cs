using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class TrackingAPIController : ControllerBase
          {
                    private readonly IITrackingServiceRepository _itrackingService;
                    public TrackingAPIController(IITrackingServiceRepository itrackingService)

                    {
                              this._itrackingService = itrackingService;

                    }

                    [HttpPost("update-location")]
                    public async Task<IActionResult> UpdateLocation(LocationUpdateDto dto)
                    {
                              var success = await _itrackingService.UpdateDeliveryLocationAsync(dto.OrderId, dto.Latitude, dto.Longitude);

                              if (!success)
                                        return NotFound(new { success = false, message = "Order not found" });

                              return Ok(new { success = true, message = "Location broadcasted successfully" });
                    }
                    [HttpGet("get-all-orders")]
                  public List<Order> GetAllOrdersAsync()
                    {
                              var listorders = _itrackingService.GetAllOrdersAsync().ToList();
                              return listorders;

                    }
                    [HttpGet("Allorderitem")]

                    public List<OrderItem> AllOrderItem()
                    {
                              var listorderitem = _itrackingService.AllOrderItem().ToList();
                              return listorderitem;         
                    }
                    [HttpGet("Allorderitem/{OrderId}")]
                    public ActionResult<List<OrderItem>> AllOrderItems(int OrderId)
                    {
                              try
                              {
                                        var listorderitem = _itrackingService.AllOrderItems(OrderId);

                                        if (listorderitem == null || listorderitem.Count == 0)
                                        {
                                                  return NotFound(new { message = $"No order items found for Order ID: {OrderId}" });
                                        }

                                        return Ok(listorderitem);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { message = "Internal server error", error = ex.Message });
                              }
                    }
                    [HttpPost("AddOrder")]        
                    public void AddOrder(Order addorder)
                    {
                              _itrackingService.AddOrder(addorder);   
                    }
                    [HttpPost("AddOrderItem")]    
                    public void AddOrderItem(OrderItem ordersitem)
                    {
                              _itrackingService.AddOrderItem(ordersitem);
                    }

          }
}
