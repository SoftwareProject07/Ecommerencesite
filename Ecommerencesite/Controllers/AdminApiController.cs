using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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

                    public IActionResult CREATERegisterAdmin(AdminREGMODEL model)
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
                    public ResponseModel LoginAdmin(AdminLogindto adminloginDto)
                    {
                              return _adminrepostiory.LOGINAdmin(adminloginDto);
                    }
                    [HttpPut("UPDATERegisterAdmin")]

                    public IActionResult UPDATERegisterAdmin(AdminREGMODEL model)
                    {
                              try
                              {
                                        if (model == null)
                                                  return BadRequest("Invalid Data");
                                        var result = _adminrepostiory.UPDATERegistoryAdmin(model);
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
                    [HttpDelete("DeleteAdmin/{id}")]
                    public IActionResult DeleteAdmin(int id)
                    {
                              try
                              {
                                        var result = _adminrepostiory.DeleteAdmin(id);
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
                    [HttpGet("GETRegisterAdmin/{id}")]
                    public IActionResult GETRegisterAdmin(int id)
                    {
                              try
                              {
                                        var result = _adminrepostiory.GETRegistoryAdmin(id);
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
                    [HttpGet("GETALLRegisterAdmin")]


                    public   IActionResult GETALLRegisterAdmin()
                              {

                                        try
                                        {
                                                  var result = _adminrepostiory.GETALLRegistoryAdmin();
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
          }
}