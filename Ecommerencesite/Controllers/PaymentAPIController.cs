//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Ecommerencesite.Controllers
//{
//          [Route("api/[controller]")]
//          [ApiController]
//          public class PaymentAPIController : ControllerBase
//          {
//          }
//}




using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class PaymentAPIController : ControllerBase
          {
                    private readonly IPaymentService _paymentService;

                    // Constructor Injection for Business Layer Interface
                    public PaymentAPIController(IPaymentService paymentService)
                    {
                              _paymentService = paymentService;
                    }

                    // 1. Validate VPA Endpoint
                    // Route: POST api/PaymentAPI/validate-vpa
                    [HttpPost("validate-vpa")]
                    public async Task<IActionResult> ValidateVpa([FromBody] string vpa)
                    {
                              if (string.IsNullOrWhiteSpace(vpa))
                              {
                                        return BadRequest(new { isValid = false, message = "UPI ID / VPA is required." });
                              }

                              bool isValid = await _paymentService.ValidateVpaAsync(vpa);

                              if (isValid)
                              {
                                        return Ok(new { isValid = true, message = "Valid UPI ID" });
                              }

                              return BadRequest(new { isValid = false, message = "Galt UPI ID / VPA. Kripya sahi ID dalein." });
                    }

                    // 2. Create UPI Payment Link Endpoint
                    // Route: POST api/PaymentAPI/create-upi-payment
                    [HttpPost("create-upi-payment")]
                    public async Task<IActionResult> CreateUpiPayment([FromBody] UpiPaymentVPARequest request)
                    {
                              if (request == null || string.IsNullOrWhiteSpace(request.Vpa))
                              {
                                        return BadRequest(new UpiPaymentVPAResponse
                                        {
                                                  IsValidVpa = false,
                                                  Message = "UPI ID and Amount are required."
                                        });
                              }

                              var result = await _paymentService.CreateUpiPaymentAsync(request);

                              if (!result.IsValidVpa)
                              {
                                        return BadRequest(result);
                              }

                              return Ok(result);
                    }
          }
}