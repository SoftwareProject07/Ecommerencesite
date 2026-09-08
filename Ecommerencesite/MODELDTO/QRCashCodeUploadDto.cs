using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class QRCashCodeUploadDto
          {
                    [Required]
                    public IFormFile QRImage { get; set; }
          }
}
