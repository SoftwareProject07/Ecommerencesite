using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class MEDICINEController : ControllerBase
          {
                    public readonly IMedicineRepositort imedicineresp;
                    public MEDICINEController(IMedicineRepositort _imedicineresp)
                    {
                              this.imedicineresp = _imedicineresp;
                    }

                
                    [HttpPost("CreateMedicine")]
                    public IActionResult CreateMedicine([FromBody] Medicine createMedicine)
                    {
                              try
                              {
                                        if (createMedicine == null)
                                                  return BadRequest("Invalid Data");

                                        var result = imedicineresp.CreateMedicine(createMedicine);
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

                    [HttpDelete("DeleteMedicine")]
                    public IActionResult DeleteMedicine(int id)
                    {
                              try
                              {
                                        var delte = imedicineresp.DeleteMedicine(id);
                                        return Ok(delte);
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
                    [HttpGet("DetailsMedicine")]
                    public IActionResult DetailsMedicine(int id)
                    {
                              try
                              {
                                        var details = imedicineresp.DetailsMedicine(id);
                                        return Ok(details);
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
                    
                    [HttpGet("SearchMedicinename")]
                    public IActionResult SearchMedicine(int id)
                    {
                              try
                              {
                                        var SearchMedicines = imedicineresp.SearchMedicine(id);
                                        return Ok(SearchMedicines);
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
                    //[HttpPut("UpdateMedicine")]
                    //public IActionResult UpdateMedicine(Medicine updatemedicine)
                    //{
                    //          try
                    //          {
                    //                    if (updatemedicine == null)
                    //                              return BadRequest("Invalid Data");
                    //                    var updatemedicines = imedicineresp.UpdateMedicine(updatemedicine);
                    //                    return Ok(updatemedicines);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new
                    //                    {
                    //                              Message = "Internal Error",
                    //                              Error = ex.Message,
                    //                              Detail = ex.InnerException?.Message
                    //                    });
                    //          }

                    //}

                    [HttpPut("UpdateMedicine")]
                    public IActionResult UpdateMedicine([FromBody] Medicine updatemedicine)
                    {
                              //try
                              //{
                              //          if (updatemedicine == null || updatemedicine.id == 0)
                              //                    return BadRequest("Invalid Medicine Data");

                              //          var result = imedicineresp.UpdateMedicine(updatemedicine);
                              //          return Ok(result);
                              //}
                              //catch (Exception ex)
                              //{
                              //          return StatusCode(500, new
                              //          {
                              //                    Message = "Internal Error",
                              //                    Error = ex.Message,
                              //                    Detail = ex.InnerException?.Message
                              //          });
                              //}
                              imedicineresp.UpdateMedicine(updatemedicine);
                              return Ok(new
                              {
                                        status = true,
                                        message = "Medicine updated successfully"
                              });


                    }

                    [HttpGet("AllListMedicineProduct")]
                    public IActionResult lstmedicine()
                    {
                              try
                              {
                                        var list = imedicineresp.lstmedicine();
                                        return Ok(list);
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

                    //[HttpGet("AllListMedicineProduct")]
                    //public IActionResult lstmedicine()
                    //{
                    //          try
                    //          {
                    //                    var list = imedicineresp.lstmedicine();

                    //                    if (list == null || list.Count == 0)
                    //                    {
                    //                              return Ok(new
                    //                              {
                    //                                        status = false,
                    //                                        data = new List<Medicine>(),
                    //                                        message = "No medicine found"
                    //                              });
                    //                    }

                    //                    return Ok(new
                    //                    {
                    //                              status = true,
                    //                              data = list
                    //                    });
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new
                    //                    {
                    //                              Message = "Internal Server Error",
                    //                              Error = ex.Message,
                    //                              Detail = ex.InnerException?.Message
                    //                    });
                    //          }
                    //}


                    // AddToCART: Add other API methods here
                    //[HttpPost]
                    //[Route("AddToCART")]
                    //public ResponseModel AddToCART(Cart cart)
                    //{
                    //          ResponseModel response = new ResponseModel();
                    //          DALMODEL DL = new DALMODEL();
                    //          SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                    //          response = DL.AddToCART(cart, conn);
                    //          return response;

                    //}
                    //[HttpPost]
                    //[Route("PlaceOrder")]
                    //public ResponseModel PlaceOrder(UserMedicine userm)
                    //{
                    //          ResponseModel response = new ResponseModel();
                    //          DALMODEL DL = new DALMODEL();
                    //          SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                    //          response = DL.PlaceOrder(userm, conn);
                    //          return response;
                    //}
                    //[HttpPost]
                    //[Route("OrderList")]
                    //public ResponseModel OrderList(UserMedicine _usermedicine)
                    //{
                    //          ResponseModel response = new ResponseModel();
                    //          DALMODEL DL = new DALMODEL();
                    //          SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                    //          response = DL.OrderList(_usermedicine, conn);
                    //          return response;
                    //}

          }
}