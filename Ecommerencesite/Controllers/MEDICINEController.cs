using Azure;
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


                    //[HttpPost("CreateMedicine")]
                    //public async Task<IActionResult> AddMedicine([FromForm] Medicine medicine, IFormFile image)
                    //{
                    //          var result = await imedicineresp.CreateMedicineAsync(medicine, image);

                    //          if (result.status == false)
                    //          {
                    //                    // 400 Bad Request bhejega duplicate hone par
                    //                    return BadRequest(new { message = result.responseMessage });
                    //          }

                    //          // 200 OK bhejega success hone par
                    //          return Ok(new { message = result.responseMessage });
                    //}
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





















                    //[HttpGet("MyMedicineProducts/{userId}")]
                    //public IActionResult GetMyMedicines(int userId)
                    //{
                    //          try
                    //          {
                    //                    var result = imedicineresp.GetUserSpecificMedicines(userId);
                    //                    if (result == null) return NotFound();
                    //                    return Ok(result);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, ex.Message);
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