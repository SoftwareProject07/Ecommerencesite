using Azure;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;


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
                    public async Task<IActionResult> CreateMedicine([FromForm] Medicine medicine, IFormFile image)
                    {
                              var result = await imedicineresp.CreateMedicineAsync(medicine, image);

                              // Agar status false hai, to hum 400 Bad Request bhej sakte hain ya 200 ke andar status false
                              return Ok(result);
                    }

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
                    //public void  UpdateMedicine(Medicine medicine)
                    //{
                    //       imedicineresp.UpdateMedicine(medicine);
                    //        //  return Ok(result);
                    //}


                    [HttpPut("UpdateMedicine")]
                    public IActionResult Update(Medicine medicine)
                    {
                              try
                              {
                                        // Call the void business logic method
                                        imedicineresp.UpdateMedicine(medicine);

                                        // If it succeeds with no exceptions, return success
                                        return Ok(new ResponseModel
                                        {
                                                   status = true,
                                                  responseMessage = "Medicine updated successfully."
                                        });
                              }
                              catch (ArgumentNullException ex)
                              {
                                        return BadRequest(new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = ex.Message
                                        });
                              }
                              catch (KeyNotFoundException ex)
                              {
                                        return NotFound(new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = ex.Message
                                        });
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = $"An unexpected error occurred: {ex.Message}"
                                        });
                              }
                    }
                    [HttpGet("AllListMedicineProduct")]
                    public IActionResult lstmedicine()
                    {
                              try
                              {
                                        var list = imedicineresp.GetAllMedicine();
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





                    















                              [HttpPost("UploadExcel")]
                    public async Task<IActionResult> UploadExcel( IFormFile file)
                    {
                              // 1. वैलीडेशन: क्या फ़ाइल भेजी गई है?
                              if (file == null || file.Length == 0)
                              {
                                        return BadRequest(new { success = false, message = "Please upload a valid Excel file!" });
                              }

                              var extension = Path.GetExtension(file.FileName).ToLower();
                              if (extension != ".xlsx" && extension != ".xls")
                              {
                                        return BadRequest(new { success = false, message = "Only .xlsx or .xls formats are allowed." });
                              }

                              try
                              {
                                        using (var stream = new MemoryStream())
                                        {
                                                  await file.CopyToAsync(stream);
                                                  stream.Position = 0;

                                                  // 2. Business Layer Call: एक्सेल पार्स करें (बिना userId के)
                                                  var parsedMedicines = await imedicineresp.ParseMedicineExcelAsync(stream);

                                                  if (parsedMedicines == null || !parsedMedicines.Any())
                                                  {
                                                            return BadRequest(new { success = false, message = "The Excel file is empty or incorrectly formatted!" });
                                                  }

                                                  // 3. Business Layer Call: डेटाबेस में सेव करें
                                                  int savedCount = await imedicineresp.BulkInsertMedicinesAsync(parsedMedicines);

                                                  // 4. Business Layer Call: पूरी लिस्ट बिना किसी फिल्टर के प्राप्त करें
                                                  ResponseModel response = imedicineresp.GetAllMedicine();
                                                 // imedicineresp.GetAllMedicine();

                                                  return Ok(new
                                                  {
                                                            success = true,
                                                            //  message = $"सफलतापूर्वक {savedCount} दवाइयां अपलोड हो गई हैं!",
                                                            message = $"{savedCount} medications successfully uploaded!!",
                                                            count = savedCount,
                                                              data = response.Data // 👈 यह बिना फ़िल्टर का पूरा साझा डेटा रिएक्ट को देगा
                                                           // data = GetAllMedicine()
                                                  });
                                        }
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(StatusCodes.Status500InternalServerError, new
                                        {
                                                  success = false,
                                                  message = "A server error has occurred.!",
                                                  error = ex.Message
                                        });
                              }
                    }
          }

          }
