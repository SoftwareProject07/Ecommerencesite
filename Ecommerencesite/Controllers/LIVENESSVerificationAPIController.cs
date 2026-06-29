using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Migrations;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerencesite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LIVENESSVerificationAPIController : ControllerBase
    {
                    public readonly ILivenessRepository _livenrespos;
                    public LIVENESSVerificationAPIController(ILivenessRepository livenrespos)
                    {
                              this._livenrespos = livenrespos;

                    }
                    //[HttpPost("verify-blink")]
                    //public async Task<IActionResult> VerifyBlink([FromBody] LivenessCheckRequestModel request)
                    //{
                    //          var result = await _livenrespos.VerifyBlinkAsync(request);
                    //          return Ok(result);
                    //}
                    //[HttpPost("verify-blink")]
                    //public IActionResult VerifyBlink([FromBody] LivenessCheckRequestModel request)
                    //{
                    //          if (request == null)
                    //          {
                    //                    return BadRequest("Request is null");
                    //          }

                    //          return Ok(new
                    //          {
                    //                    isLive = true,
                    //                    message = "API Hit Successfully",
                    //                    data = request
                    //          });
                    //[HttpPost("verify-blink")]
                    //public IActionResult VerifyBlink([FromBody] LivenessCheckRequestModel request)
                    //{
                    //          if (!ModelState.IsValid)
                    //          {
                    //                    return BadRequest(ModelState);
                    //          }

                    //          return Ok(new
                    //          {
                    //                    isLive = true
                    //          });
                    //}


                    [HttpPost("verify-blink")]
                    public async Task<IActionResult> VerifyBlink([FromBody] LivenessCheckRequestModel model)
                    {
                              if (!ModelState.IsValid)
                                        return BadRequest(ModelState);

                              var result = await _livenrespos.VerifyBlinkAsync(model);


                              return Ok(result);
                    }
                    [HttpGet("AllLivenessblink")]

                    public IActionResult GetLiveness()
                    {
                              var data = _livenrespos.GetLivenessAsync().ToList();

                              return Ok(data);
                    }
          }
}
