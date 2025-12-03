using Azure;
using Ecommerencesite.DAL;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class USERMEDICINEController : ControllerBase
          {
                    private readonly IConfiguration _configuration;
                    public USERMEDICINEController(IConfiguration configuration)
                    {
                              this._configuration = configuration;

                    }

                    [HttpPost]
                    [Route("CREATERegisterUser")]
                    public ResponseModel CREATERegisterUser(UserMedicine userMedicine)
                    {

                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.CREATERegisterUser(userMedicine, conn);

                              return response;


                    }
                    [HttpPost]
                    [Route("LOGINUserMedicine")]
                    public ResponseModel LOGINUserMedicine(UserMedicine userMedicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.LOGINUserMedicine(userMedicine, conn);
                              return response;
                    }
                    [HttpPost]
                    [Route("ViewUser")]
                    public ResponseModel ViewUser(UserMedicine userMedicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.ViewUser(userMedicine, conn);
                              return response;
                    }
                    [HttpPost]
                    [Route("UpdateUserMedicine")]
                    public ResponseModel UpdateUserMedicine(UserMedicine userMedicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.UpdateUserMedicine(userMedicine, conn);
                              return response;
                    }
                    [HttpPost]
                    [Route("DELETEUserMedicine")]
                    public ResponseModel DELETEUserMedicine(UserMedicine userMedicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.DELETEUserMedicine(userMedicine, conn);
                              return response;
                    }

                    P
          }
}