using Azure;
using CRUDAPPLICATION.ModelDTO;
using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
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
                              var a = _usermedicinerepository.CUSTOMERUserList().ToList();
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

                    [HttpGet("customer-profile")]
                    public IActionResult GetCustomerProfile(int userId)
                    {
                              var data = _usermedicinerepository.Customerprofile(userId);

                              if (data == null)
                                        return NotFound("Customer profile not found");

                              return Ok(data);
                    }


                 

          }

}