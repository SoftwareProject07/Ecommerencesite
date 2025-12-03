using Ecommerencesite.DAL;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class AdminController : ControllerBase
          {
                    private readonly IConfiguration configuration;
                    public AdminController(IConfiguration _configuration)
                    {
                              this.configuration = _configuration;
                    }
                    // Add other API methods here
                    [HttpPost]
                    [Route("AddUpdateMedicine")]
                    public ResponseModel AddUpdateMedicine(Medicine medicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.AddUpdateMedicine(medicine, conn);
                              return response;
                    }
                    [HttpGet]
                    [Route("UserList")]
                    public ResponseModel UserList(UserMedicine _usermedicine)
                    {
                             ResponseModel response = new ResponseModel();
                              DALMODEL DaL = new DALMODEL();
                              SqlConnection con = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DaL.UserList(_usermedicine,con);
                              return response;
                    }
          }
}
