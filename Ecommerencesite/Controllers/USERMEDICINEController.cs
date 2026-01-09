using Azure;
using CRUDAPPLICATION.ModelDTO;
using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Controllers
{

          [Route("api/[controller]")]
          [ApiController]

          public class USERMEDICINEController : ControllerBase
          {
                    // private readonly IConfiguration _configuration;
                    private readonly IUserMedicineRepository _usermedicinerepository;
                    public USERMEDICINEController(IUserMedicineRepository usermedicinerepository)
                    {
                              this._usermedicinerepository = usermedicinerepository;
                    }

                    //[HttpPost("CREATERegisterUser")]
                    //public IActionResult CREATERegisterUser([FromBody] UserMedicine model)
                    //{
                    //          try
                    //          {
                    //                    if (model == null)
                    //                              return BadRequest("Invalid Data");

                    //                    var result = _usermedicinerepository.CREATERegisterUser(model);

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


                    //[HttpPost("CREATERegisterUser")]
                    //public async Task<IActionResult> CreateRegisterUser([FromForm] UserMedicine model, IFormFile PhotoFile)
                    //{
                    //          if (PhotoFile != null && PhotoFile.Length > 0)
                    //          {
                    //                    var fileName = Guid.NewGuid() + Path.GetExtension(PhotoFile.FileName);
                    //                    var filePath = Path.Combine("wwwroot/uploads", fileName);

                    //                    using (var stream = new FileStream(filePath, FileMode.Create))
                    //                    {
                    //                              await PhotoFile.CopyToAsync(stream);
                    //                    }

                    //                    model.Photo = { fileName};
                    //                    model.PhotoUrl = "/uploads/" + fileName; // ✅ persisted URL
                    //          }

                    //          // Save model to DB
                    //          _usermedicinerepository.CREATERegisterUser(model);
                    //          // return Ok(a);
                    //          return Ok(new { isSuccess = true, token = "..." });
                    //}

                    //[HttpPost("CREATERegisterUser")]
                    //public async Task<IActionResult> CreateRegisterUser([FromForm] UserMedicine model)
                    //{
                    //          try
                    //          {
                    //                    // ✅ PHOTO UPLOAD LOGIC (YAHAN)
                    //                    if (model.Photo != null)
                    //                    {
                    //                              var uploadsFolder = Path.Combine(
                    //                                  Directory.GetCurrentDirectory(),
                    //                                  "wwwroot",
                    //                                  "uploads"
                    //                              );

                    //                              if (!Directory.Exists(uploadsFolder))
                    //                                        Directory.CreateDirectory(uploadsFolder);

                    //                              var fileName = Guid.NewGuid() + Path.GetExtension(model.Photo.FileName);
                    //                              var filePath = Path.Combine(uploadsFolder, fileName);

                    //                              using (var stream = new FileStream(filePath, FileMode.Create))
                    //                              {
                    //                                        await model.Photo.CopyToAsync(stream);
                    //                              }

                    //                              // 🔥 dynamic base url
                    //                              var baseUrl = $"{Request.Scheme}://{Request.Host}";
                    //                              model.PhotoUrl = $"{baseUrl}/uploads/{fileName}";
                    //                    }

                    //                    // 🔐 password hash (optional but recommended)
                    //                    // model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    //                    _usermedicinerepository.CREATERegisterUser(model);
                    //                    //  await _context.SaveChangesAsync();

                    //                    return Ok(new
                    //                    {
                    //                              isSuccess = true,
                    //                              userMedicine = model
                    //                    });
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new
                    //                    {
                    //                              isSuccess = false,
                    //                              message = ex.Message
                    //                    });
                    //          }
                    //}

                    [HttpPost("CREATERegisterUser")]
                    public async Task<IActionResult> RegisterUser([FromForm] UserMedicine model, IFormFile Photo)
                    {
                              if (Photo != null && Photo.Length > 0)
                              {
                                        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                                        if (!Directory.Exists(uploads))
                                                  Directory.CreateDirectory(uploads);

                                        var fileName = Guid.NewGuid() + Path.GetExtension(Photo.FileName);
                                        var filePath = Path.Combine(uploads, fileName);

                                        using (var stream = new FileStream(filePath, FileMode.Create))
                                        {
                                                  await Photo.CopyToAsync(stream);
                                        }

                                        var baseUrl = $"{Request.Scheme}://{Request.Host}";
                                        model.PhotoUrl = $"{baseUrl}/uploads/{fileName}";
                              }

                                              _usermedicinerepository.CREATERegisterUser(model);
                              //  await _context.SaveChangesAsync();

                              return Ok(new { isSuccess = true, message = "User Registered" });
                    }


                    //[HttpPost("LOGINUserMedicine")]
                    //public IActionResult LOGINUserMedicine(UserLogindto logindto)
                    //{

                    //          var a = _usermedicinerepository.LOGINUserMedicine(logindto);
                    //          return Ok(a);
                    //}
                    [HttpPost]
                    [Route("LOGINUserMedicine")]
                    public ResponseModel LOGINUserMedicine([FromBody] UserLogindto loginDto)
                    {
                              return _usermedicinerepository.LOGINUserMedicine(loginDto);
                    }

                    [HttpGet("ViewUser)")]
                    public ResponseModel ViewUser(int id)// DETAILS OF USER      
                    {
                              var view = _usermedicinerepository.ViewUser(id);
                              return view;
                    }
                    [HttpPut]
                    [Route("UpdateUserMedicine")]
                    public ResponseModel UpdateUserMedicine(UserMedicine userMedicine)
                    {
                            
                              var update = _usermedicinerepository.UpdateUserMedicine(userMedicine);
                              return update;
                    }
                    [HttpDelete]
                    [Route("DELETEUserMedicine")]
                    public ResponseModel DELETEUserMedicine(UserMedicine userMedicine)
                    {
                          
                              var delete = _usermedicinerepository.DELETEUserMedicine(userMedicine);
                              return delete;
                    }
                    [HttpGet("AllUserList")]
                    public ResponseModel UserList() // usermedicine list dta 
                    {
                              var userlist = _usermedicinerepository.UserList();
                              return userlist;
                    }
                    [HttpGet("AllOrderList")]
                    public ResponseModel OrderList() // Usermedicine --- order list dat
                    {
                              var orderlist = _usermedicinerepository.OrderList();
                              return orderlist;
                    }



                    // forget password ----rest foreget password otp  




            
                    [HttpPost("ForgetPassword")]
                    public async Task<IActionResult> ResetPassword([FromBody] ForgetPasswordUserDto dto)
                    {
                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(new
                                        {
                                                  status = false,
                                                  message = "Invalid request data"
                                        });
                              }

                              var isReset = await _usermedicinerepository.ResetPasswordAsync(dto);

                              if (!isReset)
                              {
                                        return Ok(new
                                        {
                                                  status = false,
                                                  message = "Invalid Email"
                                        });
                              }

                              return Ok(new
                              {
                                        status = true,
                                        message = "Password reset successfully"
                              });
                    }



          }

}