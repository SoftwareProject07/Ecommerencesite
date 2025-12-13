using Azure;
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
                    // private readonly DALMODEL _dalModel;

                    // private readonly DALMODEL _dalModel;

                    //public USERMEDICINEController(IConfiguration configuration)
                    //{
                    //          this._configuration = configuration;
                    //         // _dalModel = dalModel;
                    //}
                    //public USERMEDICINEController()
                    //{
                    //          _configuration = configuration;
                    //          _dalModel = dalModel;
                    //}
                    //[HttpPost]
                    //[Route("CREATERegisterUser")]
                    //public ResponseModel CREATERegisterUser(UserMedicine userMedicine)
                    //{

                    //          ResponseModel response = new ResponseModel();
                    //          DALMODEL DL = new DALMODEL();
                    //          SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                    //          response = DL.CREATERegisterUser(userMedicine, conn);

                    //          return response;


                    //}

                    //[HttpPost]
                    //public IActionResult CREATERegisterUser([FromBody] UserMedicine userMedicine)
                    //{
                    //          ResponseModel response = new ResponseModel();

                    //          try
                    //          {
                    //                    string connectionString = _configuration.GetConnectionString("DefaultConnection");
                    //                    if (string.IsNullOrEmpty(connectionString))
                    //                    {
                    //                              response.statusCode = 500;
                    //                              response.responseMessage = "Connection string is empty";
                    //                              return Ok(response);
                    //                    }

                    //                    using (SqlConnection connection = new SqlConnection(connectionString))
                    //                    {
                    //                              if (_dalModel == null)
                    //                              {
                    //                                        response.statusCode = 500;
                    //                                        response.responseMessage = "_dalModel is null";
                    //                                        return Ok(response);
                    //                              }
                    //                              response = _dalModel.CREATERegisterUser(userMedicine, connection);
                    //                    }
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    response.statusCode = 500;
                    //                    response.responseMessage = "An error occurred: " + ex.Message;
                    //          }

                    //          return Ok(response);
                    //}
                    //[HttpPost("CREATERegisterUser")]
                    //public IActionResult CREATERegisterUser([FromBody] UserMedicine userregistMedicine)
                    //{
                    //          var a = _usermedicinerepository.CREATERegisterUser(userregistMedicine);
                    //          return Ok(a);

                    //}
                    [HttpPost("CREATERegisterUser")]
                    public IActionResult CREATERegisterUser([FromBody] UserMedicine model)
                    {
                              try
                              {
                                        if (model == null)
                                                  return BadRequest("Invalid Data");

                                        var result = _usermedicinerepository.CREATERegisterUser(model);

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

                    //[HttpGet("LOGINUserMedicine")]
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
                            var view= _usermedicinerepository.ViewUser(id);
                              return view;
                    }
                    [HttpPut]
                    [Route("UpdateUserMedicine")]
                    public ResponseModel UpdateUserMedicine(UserMedicine userMedicine)
                    {
                              //ResponseModel response = new ResponseModel();
                              //DALMODEL DL = new DALMODEL();
                              //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              //response = DL.UpdateUserMedicine(userMedicine, conn);
                              //return response;
                              var update= _usermedicinerepository.UpdateUserMedicine(userMedicine);
                              return update;
                    }
                    [HttpDelete]
                    [Route("DELETEUserMedicine")]
                    public ResponseModel DELETEUserMedicine(UserMedicine userMedicine)
                    {
                              //ResponseModel response = new ResponseModel();
                              //DALMODEL DL = new DALMODEL();
                              //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              //response = DL.DELETEUserMedicine(userMedicine, conn);
                              //return response;
                              var delete= _usermedicinerepository.DELETEUserMedicine(userMedicine);
                              return delete;
                    }
                    [HttpGet("AllUserList")]
                    public ResponseModel UserList() // usermedicine list dta 
                    {
                              var userlist= _usermedicinerepository.UserList();
                              return userlist;
                    }
                    [HttpGet("AllOrderList")]
                    public ResponseModel OrderList() // Usermedicine --- order list dat
                    {
                              var orderlist= _usermedicinerepository.OrderList();
                              return orderlist;
                    }


          }
}