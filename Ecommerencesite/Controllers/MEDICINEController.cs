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


                    //[HttpPost("CreateMedicine")]
                    //public IActionResult CreateMedicine([FromBody] Medicine createMedicine)
                    //{
                    //          try
                    //          {
                    //                    if (createMedicine == null)
                    //                              return BadRequest("Invalid Data");

                    //                    var result = imedicineresp.CreateMedicine(createMedicine);
                    //                    return Ok(result);
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

                    [HttpPost("CreateMedicine")]
                    public IActionResult CreateMedicine( Medicine createMedicine, IFormFile image)
                    {
                              try
                              {
                                        if (createMedicine == null)
                                                  return BadRequest("Invalid data");

                                        if (image == null || image.Length == 0)
                                                  return BadRequest("Image is required");

                                        // 📁 Folder create
                                        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                                        if (!Directory.Exists(uploadPath))
                                                  Directory.CreateDirectory(uploadPath);

                                        // 📸 Unique file name
                                        var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                                        var filePath = Path.Combine(uploadPath, fileName);

                                        // 💾 Save image
                                        using (var stream = new FileStream(filePath, FileMode.Create))
                                        {
                                                    image.CopyToAsync(stream);
                                        }

                                        // 🌐 Image URL
                                        createMedicine.IMAGEURL = "/images/" + fileName;

                                        // 🔥 Save to DB
                                        var medicine = new Medicine
                                        {
                                                  Name = createMedicine.Name,
                                                  Manufacturer = createMedicine.Manufacturer,
                                                  UnitPrice = createMedicine.UnitPrice,
                                                  Discount = createMedicine.Discount,
                                                  Quantity = createMedicine.Quantity,
                                                  ExpiryDate = createMedicine.ExpiryDate,
                                                  IMAGEURL = createMedicine.IMAGEURL,
                                                  STATUS = 1
                                        };

                                        var result = imedicineresp.CreateMedicine(medicine);

                                        return Ok(new
                                        {
                                                  status = true,
                                                  message = "Medicine created successfully",
                                                  image = createMedicine.IMAGEURL
                                        });
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


                    // 🔥 S

                    //[HttpDelete("DeleteMedicine")]
                    //public IActionResult DeleteMedicine(int id)
                    //{
                    //          try
                    //          {
                    //                    var delte = imedicineresp.DeleteMedicine(id);
                    //                    return Ok(delte);
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
                    //[HttpDelete("DeleteMedicine/{id}")]

                    //public IActionResult DeleteMedicine(int id)
                    //{
                    //          try
                    //          {
                    //                    var result = imedicineresp.DeleteMedicine(id);
                    //                    return Ok(result);
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
                    //[HttpPut("DeleteMedicine/{id}")]
                    //public IActionResult DeleteMedicine(int id)
                    //{
                    //          try
                    //          {
                    //                    var result = imedicineresp.DeleteMedicine(id);
                    //                    return Ok(result);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new
                    //                    {
                    //                              Message = "Delete error",
                    //                              Error = ex.Message
                    //                    });
                    //          }
                    //}

                    [HttpDelete("DeleteMedicine/{id}")]
                    public IActionResult DeleteMedicine(int id)
                    {
                              var result = imedicineresp.DeleteMedicine(id);
                              return Ok(result);
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
                    public IActionResult UpdateMedicine([FromBody] Medicine medicine)
                    {
                              var result = imedicineresp.UpdateMedicine(medicine);
                              return Ok(result);
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