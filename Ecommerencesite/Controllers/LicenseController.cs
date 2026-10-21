using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class LicenseController : ControllerBase
          {
                    public readonly ILicenseService _licenseService;
                    public LicenseController(ILicenseService licenseService)
                    {
                           this.  _licenseService = licenseService;
                    }

                    [HttpGet("ValidateClientLicenseS")]
                    public IActionResult ValidateClientLicense(int clientId)
                    {
                              bool isAllowed = _licenseService.ValidateClientLicense(clientId);
                              return Ok(new { isAllowed = isAllowed });
                    }

          }
}
