using Ecommerencesite.Businee_Layer.IBusineeLayer;
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

          }
}
