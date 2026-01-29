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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

                

                    [HttpPost("CREATERegisterUser")]
                    public async Task<IActionResult> RegisterUser([FromForm] UserMedicine model)
                    {
                              try
                              {
                                        // ✅ PHOTO UPLOAD
                                        //if (model.Photo != null && model.Photo.Length > 0)
                                        //{
                                        //          var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                                        //          if (!Directory.Exists(uploadsFolder))
                                        //                    Directory.CreateDirectory(uploadsFolder);

                                        //          var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                                        //          var filePath = Path.Combine(uploadsFolder, fileName);

                                        //          using (var stream = new FileStream(filePath, FileMode.Create))
                                        //          {
                                        //                    await model.Photo.CopyToAsync(stream); // ✅ CORRECT
                                        //          }

                                        //          // ✅ PHOTO URL SAVE
                                        //          model.PhotoUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
                                        //}

                                        _usermedicinerepository.CREATERegisterUser(model);

                                        return Ok(new
                                        {
                                                  isSuccess = true,
                                                  message = "User Registered Successfully",
                                                  user = model
                                        });
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new
                                        {
                                                  isSuccess = false,
                                                  message = ex.Message
                                        });
                              }
                    }



                    [HttpPost]
                    [Route("LOGINUserMedicine")]
                    public ResponseModel LOGINUserMedicine(UserLogindto loginDto)
                    {
                              return _usermedicinerepository.LOGINUserMedicine(loginDto);
                    }

                    //                [HttpPost("login")]
                    //                public IActionResult Login(UserLogindto model)
                    //                {
                    //                          var user = _usermedicinerepository.USER
                    //                              .FirstOrDefault(x =>
                    //                                  (x.Email == model.Email || x.PhoneNumber == model.Email)
                    //                                  && x.Password == model.Password);

                    //                          if (user == null)
                    //                                    return Unauthorized(new { status = false, message = "Invalid credentials" });

                    //                          // 🔐 JWT Generate
                    //                          var claims = new[]
                    //                          {
                    //    new Claim("UserId", user.Id.ToString()),
                    //    new Claim(ClaimTypes.Email, user.Email)
                    //};

                    //                          var key = new SymmetricSecurityKey(
                    //                              Encoding.UTF8.GetBytes(_config["Jwt:Key"])
                    //                          );

                    //                          var token = new JwtSecurityToken(
                    //                              issuer: _config["Jwt:Issuer"],
                    //                              audience: _config["Jwt:Audience"],
                    //                              claims: claims,
                    //                              expires: DateTime.Now.AddDays(1),
                    //                              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    //                          );

                    //                          return Ok(new
                    //                          {
                    //                                    status = true,
                    //                                    token = new JwtSecurityTokenHandler().WriteToken(token)
                    //                          });
                    //                }



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
                    public IActionResult UserList() // usermedicine list dta 
                      {
                            var a= _usermedicinerepository.CUSTOMERUserList().ToList();
                              return Ok(a);
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
                                                  message = "Invalid Email/phoneNumber/UserName"
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