using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class UserLogindto
          {
                    //public string? FirstName { get; set; } = null;
                    //public string? LastName { get; set; } = null;
                    public string? Email { get; set; } = null;
                    public string? Password { get; set; } = null;
                   
                    [RegularExpression(@"^([0-9]{10})$")]
                    public string? MobileNumber { get; set; } = null;

                 

          }
}
