using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class QRCASHAPIController : ControllerBase
          {
                    public readonly IQRCASHREPOSITORY _qRCASHREPOSITORY;
                    public QRCASHAPIController(IQRCASHREPOSITORY qRCASHREPOSITORY)
                    {
                              _qRCASHREPOSITORY = qRCASHREPOSITORY;
                    }


                    [HttpPost("AddQRCashCodeModels")]
                    public void AddQRCashCodeModels(QRCashCodeModels qRCashCodeModels)
                    {
                              _qRCASHREPOSITORY.AddQRCashCodeModels(qRCashCodeModels);

                    }
                    [HttpDelete("DeleteQRCashCodeModels")]
                    public QRCashCodeModels DeleteQRCashCodeModels(int id)
                    {
                              return _qRCASHREPOSITORY.DeleteQRCashCodeModels(id);
                    }

                    [HttpGet("listqucasehmodel")]
                    public List<QRCashCodeModels> listqucasehmodel()
                    {
                              return _qRCASHREPOSITORY.listqucasehmodel();
                    }
                    [HttpPut("UpdateQRCashCodeModels")]
                    public void UpdateQRCashCodeModels(QRCashCodeModels qRCashCodeModels)
                    {
                              _qRCASHREPOSITORY.UpdateQRCashCodeModels(qRCashCodeModels);
                    }


          }
}
