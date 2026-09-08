using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class QRCASHAPIController : ControllerBase
          {
                    public readonly IQRCASHREPOSITORY _qRCASHREPOSITORY;
                    private readonly IWebHostEnvironment _env;
                    public QRCASHAPIController(IQRCASHREPOSITORY qRCASHREPOSITORY, IWebHostEnvironment env)
                    {
                         this.     _qRCASHREPOSITORY = qRCASHREPOSITORY;
                          this.    _env = env;
                    }

                    [HttpPost("upload")]
                    public async Task<IActionResult> UploadQRCode([FromForm] QRCashCodeUploadDto dto)
                    {
                              try
                              {
                                        if (dto.QRImage == null)
                                                  return BadRequest(new { message = "Please select an image file." });

                                        var result = await _qRCASHREPOSITORY.UploadQRCodeAsync(dto.QRImage, _env.WebRootPath);
                                        return Ok(new { message = "QR Code uploaded successfully", data = result });
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, new { message = "Internal server error", error = ex.Message });
                              }
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
                    [HttpGet("{id}")]
        public async Task<IActionResult> GetQRCode(int id)
        {
            var qrCode = await _qRCASHREPOSITORY.GetQRCodeByIdAsync(id);
            if (qrCode == null)
                return NotFound(new { message = "QR Code not found." });

            // Returns the record containing the image URL which can be rendered in frontend as <img src="url" />
            return Ok(qrCode);
        }

          }
}
