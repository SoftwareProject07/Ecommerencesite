using Azure;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;


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
                    //public IActionResult CreateMedicine( Medicine createMedicine)
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

                    //[HttpPost("CreateMedicine")]
                    //public IActionResult CreateMedicine([FromForm] Medicine createMedicine)
                    //{
                    //          createMedicine.STATUS = 1;
                    //          imedicineresp.CreateMedicine(createMedicine);
                    //          imedicineresp();

                    //          return Ok(createMedicine);
                    //}



                    //[HttpPost("CreateMedicine")]
                    //          public ResponseModel CreateMedicine([FromBody] Medicine createMedicine)
                    //          {
                    //                    // 1️⃣ Null / empty check
                    //                    if (string.IsNullOrWhiteSpace(createMedicine.ExpiryDate))
                    //                    {
                    //                              return new ResponseModel
                    //                              {
                    //                                        status = false,
                    //                                        responseMessage = "Expiry Date is required"
                    //                              };
                    //                    }

                    //                    // 2️⃣ Allowed formats
                    //                    string[] formats =
                    //                    {
                    //        "yyyy-MM-dd",        // from <input type="date">
                    //        "dd-MM-yyyy",
                    //        "dd/MM/yyyy",
                    //        "yyyy-MM-dd HH:mm:ss"
                    //    };

                    //                    // 3️⃣ Parse string → DateTime
                    //                    if (!DateTime.TryParseExact(
                    //                        createMedicine.ExpiryDate,
                    //                        formats,
                    //                        CultureInfo.InvariantCulture,
                    //                        DateTimeStyles.None,
                    //                        out DateTime expiryDate))
                    //                    {
                    //                              return new ResponseModel
                    //                              {
                    //                                        status = false,
                    //                                        responseMessage =
                    //                                      "Expiry Date format must be yyyy-MM-dd or dd-MM-yyyy (2026-12-01 / 01-12-2026)"
                    //                              };
                    //                    }

                    //                    // 4️⃣ Future date validation
                    //                    if (expiryDate.Date <= DateTime.Today)
                    //                    {
                    //                              return new ResponseModel
                    //                              {
                    //                                        status = false,
                    //                                        responseMessage = "Expiry Date must be a future date"
                    //                              };
                    //                    }

                    //                    // 5️⃣ Save (string OR converted DateTime)
                    //                    createMedicine.ExpiryDate = expiryDate.ToString("yyyy-MM-dd");
                    //                    createMedicine.STATUS = 1;

                    //                    imedicineresp.CreateMedicine(createMedicine);

                    //                    return new ResponseModel
                    //                    {
                    //                              status = true,
                    //                              responseMessage = "Medicine created successfully",
                    //                              medicine = createMedicine
                    //                    };
                    //          }


                    //  [HttpPost("CreateMedicine")]
                    //public ResponseModel CreateMedicine([FromBody] Medicine createMedicine)
                    //{
                    //          // 1️⃣ Required check
                    //          if (string.IsNullOrWhiteSpace(createMedicine.ExpiryDate))
                    //          {
                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = "Expiry Date is required (dd/MM/yyyy)"
                    //                    };
                    //          }

                    //          // 2️⃣ ONLY dd/MM/yyyy format
                    //          if (!DateTime.TryParseExact(
                    //              createMedicine.ExpiryDate,
                    //              "dd/MM/yyyy",
                    //              CultureInfo.InvariantCulture,
                    //              DateTimeStyles.None,
                    //              out DateTime expiryDate))
                    //          {
                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = "Expiry Date format must be dd/MM/yyyy (12/12/2028)"
                    //                    };
                    //          }

                    //          // 3️⃣ Future date check
                    //          if (expiryDate.Date <= DateTime.Today)
                    //          {
                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = "Expiry Date must be a future date"
                    //                    };
                    //          }

                    //          // 4️⃣ Save (string as-is or normalized)
                    //          createMedicine.ExpiryDate = expiryDate.ToString("dd/MM/yyyy");
                    //          createMedicine.STATUS = 1;

                    //                    imedicineresp.CreateMedicineAsync(createMedicine);

                    //          return new ResponseModel
                    //          {
                    //                    status = true,
                    //                    responseMessage = "Medicine created successfully",
                    //                    medicine = createMedicine
                    //          };
                    //}


                    [HttpPost("CreateMedicine")]
                    public async Task<IActionResult> CreateMedicine([FromForm] Medicine medicine, IFormFile image)
                    {
                              if (!ModelState.IsValid)
                                        return BadRequest(ModelState);

                              if (image == null || image.Length == 0)
                                        return BadRequest("Image missing");

                              await imedicineresp.CreateMedicineAsync(medicine, image);

                              return Ok("Medicine created successfully");
                    }

                    //[HttpPost("CreateMedicine")]
                    //public async Task<IActionResult> CreateMedicine([FromForm] Medicine medicine, IFormFile image)
                    //{
                    //          if (!ModelState.IsValid)
                    //                    return BadRequest(ModelState);

                    //          if (image == null || image.Length == 0)
                    //                    return BadRequest("Image missing");

                    //          await imedicineresp.CreateMedicineAsync(medicine, image);

                    //          return Ok("Medicine created successfully");
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