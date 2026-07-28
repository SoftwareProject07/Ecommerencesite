using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
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

                    // Master Admin type add option
                    [HttpPost("AddAdminType")]
                    public void AddAdminType(AdminTypeModel adminTypeModel)
                    {
                              _adminrepostiory.AddAdminType(adminTypeModel);
                    }
                    [HttpGet("AllTypeList")]

                    public List<AdminTypeModel> typelist()                    {
                              return _adminrepostiory.typelist();
                    }
                    [HttpPut("updatetype")]
                    public void UpdateAdminType(AdminTypeModel adminTypeModel)
                    {
                              _adminrepostiory.UpdateAdminType(adminTypeModel);
                    }


                    [HttpDelete("DeleteType")]

                    public AdminTypeModel DeleteAdmintype(int id)
                    {
                       var deleteadmintype=       _adminrepostiory.DeleteAdmintype(id);
                              return deleteadmintype;
                    }


          }
}