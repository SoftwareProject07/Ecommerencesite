using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class AdminApiController : ControllerBase
          {
                    private readonly IAdminRepository _adminrepostiory;
                    public AdminApiController(IAdminRepository adminrepostiory)
                    {
                              this._adminrepostiory = adminrepostiory;
                    }

                    [HttpPost("CREATERegisterAdmin")]

                    public IActionResult CREATERegisterAdmin([FromBody] AdminREGMODEL model)
                    {
                              try
                              {
                                        if (model == null)
                                                  return BadRequest("Invalid Data");

                                        var result = _adminrepostiory.CREATERegistoryAdmin(model);

                                        return Ok(result);
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
                    [HttpPost("LOGINAdmin")]
                  //  [Route("LOGINUserMedicine")]
                    public ResponseModel LoginAdmin([FromBody]  AdminLogindto adminloginDto)
                    {
                            return  _adminrepostiory.LOGINAdmin(adminloginDto);
                    }


          }
}
