using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class AdminLogindto
          {
                    [EmailAddress]
                    public string? Email { get; set; } = null;
                    public string? Password { get; set; } = null;
          }
}
