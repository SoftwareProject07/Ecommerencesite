using Ecommerencesite.Businee_Layer.IBusineeLayer;
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
                    [HttpPost("verify-blink")]
                    public async Task<IActionResult> VerifyBlink([FromBody] LivenessCheckRequestModel request)
                    {
                              var result = await _livenrespos.VerifyBlinkAsync(request);
                              return Ok(result);
                    }
          }
}
