using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class AdminLogindto
          {
                    public string? Email { get; set; } = null;
                    public string? Password { get; set; } = null;
                    public string? MobileNumber { get; set; } = null;
                    public string? ROLE { get; set; } = null;         
          }
}
