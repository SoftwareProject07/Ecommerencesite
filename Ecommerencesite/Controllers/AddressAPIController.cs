using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.BuilderProperties;
using System;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class AddressAPIController : ControllerBase
          {
                    private readonly Ecommerecewebstedatabase _context;
                    public AddressAPIController(Ecommerecewebstedatabase context)
                    {
                            this._context = context;
                    }

                    [HttpPost("AddAddress")]
                    public async Task<IActionResult> SaveAddress([FromBody] AddressDto dto)
                    {
                              var address = new deliverypartnermodel
                              {
                                        UserId = dto.UserId,
                                        AddressLine = dto.AddressLine,
                                        City = dto.City,
                                        Pincode = dto.Pincode,
                                        Latitude = dto.Latitude,
                                        Longitude = dto.Longitude
                              };

                              _context.deliverypartnermodels.Add(address);
                              await _context.SaveChangesAsync();

                              return Ok(new { success = true, message = "Address saved successfully", addressId = address.Id });
                    }
          }
}
