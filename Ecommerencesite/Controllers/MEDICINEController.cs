using Ecommerencesite.DAL;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class MEDICINEController : ControllerBase
          {
                    private readonly IConfiguration configuration;
                    public MEDICINEController(IConfiguration _configuration)
                    {
                            this.configuration = _configuration;
                    }
                    // AddToCART: Add other API methods here
                    [HttpPost]
                    [Route("AddToCART")]
                    public ResponseModel AddToCART(Cart cart)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.AddToCART(cart, conn);
                              return response;

                    }
                    [HttpPost]
                    [Route("PlaceOrder")]
                    public ResponseModel PlaceOrder(UserMedicine userm)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.PlaceOrder(userm, conn);
                              return response;
                    }
                    [HttpPost]
                    [Route("OrderList")]
                    public ResponseModel OrderList(UserMedicine _usermedicine)
                    {
                              ResponseModel response = new ResponseModel();
                              DALMODEL DL = new DALMODEL();
                              SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Ecommerecewebstedatabase").ToString());
                              response = DL.OrderList(_usermedicine, conn);
                              return response;
                    }
          }
}
